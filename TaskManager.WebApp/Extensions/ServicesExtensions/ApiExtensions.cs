using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TaskManager.WebApp.Middleware;

namespace TaskManager.WebApp.Extensions.ServicesExtensions
{
    public static class ApiExtensions
    {
        public static IServiceCollection AddFilters(this IServiceCollection services)
        {
            services.AddScoped(typeof(ValidatorFilter<>));

            return services;
        }

        public static IServiceCollection AddFueltValidationValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining(typeof(Program), includeInternalTypes: true);
            return services;
        }
    }
}
