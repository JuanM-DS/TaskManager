using Microsoft.EntityFrameworkCore.Diagnostics;

namespace TaskManager.WebApp.Persistence.EntityFramework.Context.Interceptors
{
    public class AuditableInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
