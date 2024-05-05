using MediatR;

namespace Dr_Purple.Application.Services.ServiceServices.Commands;
public record CreateServiceTimeCommand(int Interval) : IRequest<Unit>;