using Dr_Purple.Application.Constants.Notification;
using Dr_Purple.Application.Services.ServiceServices.Commands;
using MediatR;
using Microsoft.Extensions.Hosting;

namespace Dr_Purple.Application.Background_Tasks;
public class ServiceTimeScheduler : IHostedService
{
    private readonly ITaskSettingsService TaskSettingsService;
    private readonly IMediator Mediator;
    private Timer? Timer;

    public ServiceTimeScheduler(ITaskSettingsService taskSettingsService, IMediator mediator)
    {
        TaskSettingsService = taskSettingsService;
        Mediator = mediator;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await Task.WhenAll();
        Timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromDays(TaskSettingsService.GetTimeSlotGenerateDays()));
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        Timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    private void DoWork(object? state)
    {
        Mediator.Send(new CreateServiceTimeCommand(TaskSettingsService.GetTimeSlotGenerateDays()));
    }
}