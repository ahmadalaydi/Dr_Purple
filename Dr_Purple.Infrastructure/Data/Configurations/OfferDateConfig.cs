using Dr_Purple.Domain.Entities.Offers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
internal sealed class OfferDateConfig : IEntityTypeConfiguration<OfferDate>
{
    public void Configure(EntityTypeBuilder<OfferDate> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.OfferId).IsRequired();
        builder.Property(_ => _.StartDate).IsRequired();
        builder.Property(_ => _.EndDate).IsRequired();

        builder.HasOne(_ => _.Offer)
                .WithMany(_ => _.OfferDates)
                .HasForeignKey(_ => _.OfferId);
    }
}