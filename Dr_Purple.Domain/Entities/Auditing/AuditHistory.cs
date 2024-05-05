using Dr_Purple.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dr_Purple.Domain.Entities.Auditing;

public class AuditHistory : IEntity
{
    public long Id { get; set; }
    public string RowId { get; set; } = string.Empty;
    public string TableName { get; set; } = string.Empty;
    public string Changed { get; set; } = string.Empty;
    public EntityState Kind { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public string Username { get; set; } = string.Empty;
    public AutoHistoryDetails AutoHistoryDetails { get; set; } = new AutoHistoryDetails();
}