using Dr_Purple.Domain.Entities.Appointments;
using Dr_Purple.Domain.Entities.Services;
using Dr_Purple.Domain.Entities.Services.State;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
internal sealed class ServiceTimeConfig : IEntityTypeConfiguration<ServiceTime>
{
    public void Configure(EntityTypeBuilder<ServiceTime> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.StartTime).IsRequired();
        builder.Property(_ => _.Date).IsRequired()
               .HasConversion(v => v.ToDateTime(default),
                              v => DateOnly.FromDateTime(v));

        builder.Property(_ => _.EndTime).IsRequired();

        builder.HasOne(_ => _.Service)
               .WithMany(_ => _.ServiceTimes)
               .HasForeignKey(_ => _.ServiceId);


        builder.HasOne(_ => _.ContractService)
               .WithMany(_ => _.ServiceTimes)
               .HasForeignKey(_ => _.ContractServiceId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(_ => _.Appointment)
               .WithOne(_ => _.ServiceTime)
               .HasForeignKey<Appointment>(_ => _.ServiceTimeId);

        builder.Property(_ => _.State)
               .HasConversion(_ => _.GetType().Name,
               _ => GetServiceTimeState(_));
    }

    private static IServiceTimeState GetServiceTimeState(string state)
        => state switch
        {
            nameof(BookedServiceTimeState) => new BookedServiceTimeState(),
            nameof(CanceledServiceTimeState) => new CanceledServiceTimeState(),
            nameof(DoneServiceTimeState) => new DoneServiceTimeState(),
            nameof(FreeServiceTimeState) => new FreeServiceTimeState(),
            nameof(LeavedServiceTimeState) => new LeavedServiceTimeState(),
            _ => throw new NotImplementedException(),
        };
}