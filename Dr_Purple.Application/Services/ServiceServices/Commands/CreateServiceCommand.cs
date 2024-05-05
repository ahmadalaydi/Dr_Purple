using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.ServiceServices.Commands;

public record CreateServiceCommand(
    long SubDepartmentId,
    string Name,
    string Duration,
    float Price,
    string Description) : IRequest<IResult>;