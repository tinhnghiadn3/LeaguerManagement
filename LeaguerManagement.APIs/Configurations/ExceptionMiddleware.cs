using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using LeaguerManagement.Entities.Utilities;
using LeaguerManagement.Entities.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;

namespace LeaguerManagement.APIs.Configurations
{
    public static class ExceptionConfig
    {
        public static void UserExceptionMiddleware(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            var logger = app.ApplicationServices.GetService<ILogger>();
            app.UseExceptionHandler(new ExceptionHandlerOptions
            {
                ExceptionHandler = new ExceptionMiddleware(env, logger).Invoke
            });
        }

        public static string GetErrorMessages(this Exception ex)
        {
            if (ex == null)
                return null;

            if (ex.InnerException != null)
            {
                return ex.Message + ": " + ex.InnerException.Message;
            }

            return ex.Message;
        }
    }

    public class ExceptionMiddleware
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILogger _logger;

        public ExceptionMiddleware(IWebHostEnvironment env, ILogger logger)
        {
            _env = env;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var ex = context.Features.Get<IExceptionHandlerFeature>()?.Error;
            if (ex == null)
                return;
            //
            // Log
            _logger.Error(ex);
            //
            // Convert to model
            var error = new AppErrorModel(ex.Message, _env.IsDevelopment() ? ex.StackTrace : null);
            //
            // Return exception message as JSON
            error.Message = ex switch
            {
                AppException appException when !string.IsNullOrEmpty(appException.Message) => appException
                    .GetErrorMessages(),
                { } exception when !string.IsNullOrEmpty(exception.Message) => "Something Bad Happened",
                _ => error.Message
            };
            //
            // Return as json
            context.Response.ContentType = "application/json";
            await using var writer = new StreamWriter(context.Response.Body);
            new CamelCaseJsonSerializer().Serialize(writer, error);
            await writer.FlushAsync().ConfigureAwait(false);
        }
    }
}
