using Dr_Purple.Application.Services.ReportServices.Commands;
using MediatR;
using Microsoft.Extensions.Hosting;

namespace Dr_Purple.Application.Background_Tasks;
public class AppointmentPerContractScheduler : IHostedService
{
    private readonly IMediator Mediator;
    private Timer? Timer;

    public AppointmentPerContractScheduler(IMediator mediator)
        => Mediator = mediator;

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await Task.WhenAll();
        Timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromDays(1));
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        Timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    private void DoWork(object? state)
    {
        Mediator.Send(new CreateAppointmentPerContractCommand(DateOnly.FromDateTime(DateTime.Now.Date))).Wait();
    }
}