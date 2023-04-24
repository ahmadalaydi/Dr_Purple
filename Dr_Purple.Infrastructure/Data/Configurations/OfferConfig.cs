using Dr_Purple.Domain.Entities.Offers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
internal sealed class OfferConfig : IEntityTypeConfiguration<Offer>
{
    public void Configure(EntityTypeBuilder<Offer> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.Id).IsRequired();
        builder.Property(_ => _.Name).IsRequired().HasMaxLength(50);
        builder.Property(_ => _.Discount).IsRequired();
        builder.Property(_ => _.IsPercent).IsRequired();
        builder.Property(_ => _.IsUnlimited).IsRequired();

        builder.HasMany(_ => _.OfferDates)
                .WithOne(_ => _.Offer);

        builder.HasMany(_ => _.PaymentOffers)
                .WithOne(_ => _.Offer);
    }
}