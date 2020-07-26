using Microsoft.Extensions.DependencyInjection;
using Roteirizador.Data.Context;
using Roteirizador.Data.Repositories;
using Roteirizador.Domain.Core.Notifications;
using Roteirizador.Domain.Repositories;
using Roteirizador.Domain.Services;
using Roteirizador.Domain.Validators;

namespace Roteirizador.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services)
        {
            services.AddScoped<INotificator, Notificator>();
            services.AddScoped<RouterDbContext>();

            RegisterRepositoriesDependencies(services);
            RegisterValidatorDependencies(services);
            RegisterServiceDependencies(services);

            return services;
        }

        private static void RegisterRepositoriesDependencies(IServiceCollection services)
        {
            services.AddTransient<IUFRepository, UFRepository>();
        }
        private static void RegisterValidatorDependencies(IServiceCollection services)
        {
            services.AddTransient<IUFValidator, UFValidator>();
        }
        private static void RegisterServiceDependencies(IServiceCollection services)
        {
            services.AddTransient<IUFService, UFService>();
        }
    }
}