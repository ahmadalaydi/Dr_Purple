using Dr_Purple.Infrastructure.Auditing.Attributes;
using Microsoft.EntityFrameworkCore;

namespace Dr_Purple.Infrastructure.Auditing.Models;

[NotAuditable]
public class AuditHistory
{
    public int Id { get; set; }
    public string RowId { get; set; }
    public string TableName { get; set; }
    public string Changed { get; set; }
    public EntityState Kind { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public string Username { get; set; }
    public AutoHistoryDetails AutoHistoryDetails { get; set; } = new AutoHistoryDetails();
}
