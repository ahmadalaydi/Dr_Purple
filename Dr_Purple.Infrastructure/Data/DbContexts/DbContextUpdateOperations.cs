using Dr_Purple.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Dr_Purple.Infrastructure.Data.DbContexts;
internal static class DbContextUpdateOperations
{
    public static void UpdateDates(IEnumerable<EntityEntry<AuditableEntity>> changes, string userId)
    {
        if (!string.IsNullOrEmpty(userId))
        {
            foreach (var change in changes)
            {
                if (change.State == EntityState.Added)
                {
                    change.Entity.CreatedBy = userId;
                    change.Entity.ModifiedBy = userId;
                    change.Entity.DateCreated = DateTime.UtcNow;
                    change.Entity.DateModified = DateTime.UtcNow;
                }

                if (change.State == EntityState.Modified)
                {
                    change.Entity.ModifiedBy = userId;
                    change.Entity.DateModified = DateTime.UtcNow;
                }
            }
        }
    }
}