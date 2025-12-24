using Microsoft.EntityFrameworkCore;
using TaskManager.WebApp.Persistence.EntityFramework.Context;
using TaskManager.WebApp.Persistence.EntityFramework.Context.Interceptors;

namespace TaskManager.WebApp.Extensions.ServicesExtensions
{
    public static class PersistenceExtensions
    {
        public static IServiceCollection AddMainDbContext(this IServiceCollection services, IConfiguration confi)
        {
            services.AddDbContext<AppDbContext>((sp, option) =>
            {
                var interceptor = sp.GetRequiredService<AuditableInterceptor>();

                option.UseSqlServer(confi.GetConnectionString("MainConnectionString"),
                                    x=>x.MigrationsAssembly(typeof(Program).Assembly))
                      .AddInterceptors(interceptor);
            });
            return services;
        }
    }
}
