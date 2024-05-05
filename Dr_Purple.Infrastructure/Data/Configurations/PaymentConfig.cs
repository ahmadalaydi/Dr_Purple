using Dr_Purple.Domain.Entities.Payments.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dr_Purple.Infrastructure.Data.Configurations;
internal sealed class PaymentConfig : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.UseTpcMappingStrategy();
        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Id).ValueGeneratedNever();

        builder.Property(_ => _.RowVersion)
                .IsConcurrencyToken()
                .ValueGeneratedOnAddOrUpdate();
    }
}