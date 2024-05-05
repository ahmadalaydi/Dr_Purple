using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.ContractServices.Commands;

public record UpdateContractCommand(
    long UserId,
    long DepartmentId,
     long JobTitleId,
     float Salary,
     DateOnly StartDate,
     DateOnly EndDate) : IRequest<IResult>
{
    public long Id { get; init; }
}