namespace Dr_Purple.Domain.Entities.Base;
public abstract class AuditableEntity
{
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public string ModifiedBy { get; set; } = string.Empty;
}