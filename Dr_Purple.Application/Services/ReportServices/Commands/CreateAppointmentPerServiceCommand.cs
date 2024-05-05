using MediatR;

namespace Dr_Purple.Application.Services.ReportServices.Commands;

public record CreateAppointmentPerServiceCommand(DateOnly Date) : IRequest<Unit>;