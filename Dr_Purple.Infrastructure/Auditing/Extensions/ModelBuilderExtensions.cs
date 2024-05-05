using Dr_Purple.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;

namespace Dr_Purple.Infrastructure.Auditing.Extensions;
public static class ModelBuilderExtensions
{
    public static ModelBuilder EnableAuditHistory(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuditHistory>().ToTable("AuditHistory", "Audit").Ignore(t => t.AutoHistoryDetails);
        modelBuilder.Entity<AuditHistory>(b =>
        {
            b.Property(c => c.Id).UseIdentityColumn(); //TODO: Possibly change this to avoid integer overflow, or cleanup every once in a while
            b.Property(c => c.RowId).IsRequired().HasMaxLength(128);
            b.Property(c => c.TableName).IsRequired().HasMaxLength(128);
            //b.Property(c => c.Changed).HasMaxLength(2048);
            b.Property(c => c.Username).HasMaxLength(128);
        });

        return modelBuilder;
    }
}
