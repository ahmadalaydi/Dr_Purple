using Dr_Purple.Domain.Entities.Payments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
internal sealed class PaymentMaterialConfig : IEntityTypeConfiguration<PaymentMaterial>
{
    public void Configure(EntityTypeBuilder<PaymentMaterial> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.PaymentId).IsRequired();
        builder.Property(_ => _.MaterialId).IsRequired();
        builder.Property(_ => _.Quantity).IsRequired();

        builder.HasOne(_ => _.Payment)
                .WithMany(_ => _.PaymentMaterials)
                .HasForeignKey(_ => _.PaymentId);

        builder.HasOne(_ => _.Material)
                .WithMany(_ => _.PaymentMaterials)
                .HasForeignKey(_ => _.MaterialId);
    }
}