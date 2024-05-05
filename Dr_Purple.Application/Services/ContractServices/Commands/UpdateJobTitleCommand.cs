using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.ContractServices.Commands;

public record UpdateJobTitleCommand(string Name) : IRequest<IResult>
{
    public long Id { get; init; }
}