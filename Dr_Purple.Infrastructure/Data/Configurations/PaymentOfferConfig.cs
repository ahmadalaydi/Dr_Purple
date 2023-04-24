using Dr_Purple.Domain.Entities.Payments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
internal sealed class PaymentOfferConfig : IEntityTypeConfiguration<PaymentOffer>
{
    public void Configure(EntityTypeBuilder<PaymentOffer> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.PaymentId).IsRequired();
        builder.Property(_ => _.OfferId).IsRequired();

        builder.HasOne(_ => _.Payment)
                .WithMany(_ => _.PaymentOffers)
                .HasForeignKey(_ => _.PaymentId);

        builder.HasOne(_ => _.Offer)
                .WithMany(_ => _.PaymentOffers)
                .HasForeignKey(_ => _.OfferId);
    }
}