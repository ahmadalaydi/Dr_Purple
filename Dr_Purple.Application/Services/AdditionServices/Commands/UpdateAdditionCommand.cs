using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.AdditionServices.Commands;

public record UpdateAdditionCommand(string Name, long ContractId) : IRequest<IResult>
{
    public long Id { get; init; }
}