using MediatR;

namespace Dr_Purple.Application.Services.ReportServices.Commands;

public record CreateAppointmentPerContractCommand(DateOnly Date) : IRequest<Unit>;