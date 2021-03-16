using Microsoft.Extensions.DependencyInjection;
using System;

namespace LeaguerManagement.Entities.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddFactory<TService>(this IServiceCollection services, Func<IServiceProvider, TService> implementationFactory)
            where TService : class
        {
            services.AddTransient(implementationFactory);
            services.AddSingleton<Func<TService>>(x => x.GetService<TService>);
        }
    }
}
