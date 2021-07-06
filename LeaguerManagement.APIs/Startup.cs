using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using AutoMapper;
using LeaguerManagement.APIs.Configurations;
using LeaguerManagement.Entities.Contexts;
using LeaguerManagement.Entities.DependencyInjection;
using LeaguerManagement.Entities.Infrastructures;
using LeaguerManagement.Entities.Utilities;
using LeaguerManagement.Entities.ViewModels;
using LeaguerManagement.Repositories.Base;
using LeaguerManagement.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NLog;
using NLog.Web;

namespace LeaguerManagement.APIs
{
    public class Startup
    {
        private readonly IConfigurationRoot _configuration;
        private readonly GlobalSettings _settings;
        private static readonly string NLogConfigPath = "nlog.config";

        public Startup(IConfiguration config)
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables();
            _configuration = configurationBuilder.Build();

            // Map AppSettings section in appsetting.json file value to AppSettings class
            _settings = config.GetSection("GlobalSettings").Get<GlobalSettings>();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<GlobalSettings>(_configuration.GetSection("GlobalSettings"));

            //
            // Register db context
            services.AddDbContext<LeaguerManagementContext>((options) =>
            {
                // Connection String
                options.UseSqlServer(_settings.ConnectionStrings)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors()
                    .LogTo(Console.WriteLine);
            }, ServiceLifetime.Transient, ServiceLifetime.Transient);
            //
            // Config cross origin
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins("http://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });
            //
            // Max size of request body
            services.Configure<FormOptions>(x =>
            {
                x.MultipartBodyLengthLimit = _settings.MaxFileSize;
            });
            //
            // JWT authentication
            var tokenKey = Encoding.ASCII.GetBytes(_settings.Token.TokenSecretKey);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(tokenKey),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
            //
            // Add Mvc
            services.AddMvc(options =>
            {
                // Respect the request response type (Accept option in request header)
                options.RespectBrowserAcceptHeader = true;
                options.EnableEndpointRouting = false;
            })
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.Formatting = Formatting.Indented;
                    options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
                    options.SerializerSettings.DateFormatString = "MM/dd/yy H:mm:ss";
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //
            // Register and Configuration JsonSerializer
            services.AddSingleton<JsonSerializer, CamelCaseJsonSerializer>();
            //
            // Mapper
            services.AddSingleton<IMapper, Mapper>();
            services.AddSingleton<AutoMapper.IConfigurationProvider>(c => new MapperConfiguration(config => config.AddProfile<AutoMapperConfig>()));
            //
            // Logger
            var logger = NLogBuilder.ConfigureNLog(NLogConfigPath).GetCurrentClassLogger();
            services.AddSingleton<ILogger>(logger);
            //
            // UnitOfWork
            services.AddFactory<IUnitOfWork>(serviceProvider =>
            {
                var scopedServiceProvider = serviceProvider.CreateScope().ServiceProvider;
                var dbContext = scopedServiceProvider.GetService<LeaguerManagementContext>();
                var httpContext = serviceProvider.GetService<IHttpContextAccessor>().HttpContext;
                var currentUser = new CurrentUserModel
                {
                    RoleId = httpContext?.AccessToken() != null ? httpContext.RoleId() : (int?)null,
                    UserId = httpContext?.AccessToken() != null ? httpContext.UserId() : (int?)null,
                };

                return new UnitOfWork(dbContext, currentUser);
            });
            //
            // Add Services
            services.AddScoped<UserService>();
            services.AddScoped<SettingService>();
            services.AddScoped<LeaguerService>();
            services.AddScoped<FileService>();
            //
            // If using IIS:
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                IdentityModelEventSource.ShowPII = true;

                app.UseDeveloperExceptionPage();
                // Enable Cors
                app.UseCors("CorsPolicy");
            }
            else
            {
                app.UseHsts();
            }

            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404
                    && !Path.HasExtension(context.Request.Path.Value)
                    && !context.Request.Path.Value.StartsWith("/api"))
                {
                    context.Request.Path = "/index.html";
                    await next();
                }
            });

            app.UserExceptionMiddleware(env);

            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    var duration = 60 * 60 * _settings.StaticFilesCachedHours;
                    //
                    // Cache vendor.***.bundle.js 10 times longer than others.
                    const string regex = @"^vendor.([a-z0-9]*).bundle.js";
                    if (Regex.Match(ctx.File.Name, regex, RegexOptions.IgnoreCase).Success)
                    {
                        duration *= 10;
                    }
                    if (ctx.File.Name.Equals("index.html"))
                    {
                        //
                        // Remove caching for index.html
                        ctx.Context.Response.Headers[HeaderNames.CacheControl] = "no-cache, no-store, must-revalidate";
                        ctx.Context.Response.Headers[HeaderNames.Pragma] = "no-cache";
                        ctx.Context.Response.Headers[HeaderNames.Expires] = "-1";
                    }
                    else
                    {
                        //
                        // Add cache for other static Files
                        ctx.Context.Response.Headers[HeaderNames.CacheControl] = "public,max-age=" + duration;
                    }
                },
                //
                // Use Static Files in the Content folder
                FileProvider = new PhysicalFileProvider(Path.Combine(Environment.CurrentDirectory, "Contents")),
                RequestPath = new PathString("/contents")
            });

            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Environment.CurrentDirectory, "Contents")),
                RequestPath = new PathString("/contents")
            });

            //app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseMvc();
            //
            // Init User Tokens
            app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserService>().InitUserTokens();
        }
    }
}
