using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using TaskManager.Domain.CommonEntities;

namespace TaskManager.WebApp.Persistence.EntityFramework.Context.Interceptors
{
    public class AuditableInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            var context = eventData.Context;
            if(context is null)
                return base.SavingChangesAsync(eventData, result, cancellationToken);

            var entries = context.ChangeTracker.Entries<IAuditableProperties>();

            foreach (var item in entries)
            {
                switch (item.State)
                {
                    case EntityState.Modified:
                        item.Entity.Updated = DateTime.UtcNow;
                        item.Entity.UpdatedBy = "Admin";
                        break;
                    
                    case EntityState.Added:
                        item.Entity.Created= DateTime.UtcNow;
                        item.Entity.CreatedBy = "Admin";
                        break;

                    default:
                        break;
                }
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
