using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.AdditionServices.Commands;

public record CreateAdditionCommand(
    string Name,
    long ContractId) : IRequest<IResult>;