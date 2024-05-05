namespace Dr_Purple.Domain.Attributes;
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class NotAuditableAttribute : Attribute
{
    public bool Enabled { get; set; }

    public NotAuditableAttribute(bool nonAuditable = true)
        => Enabled = nonAuditable;
}