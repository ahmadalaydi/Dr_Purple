using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Services;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.ServiceServices.Queries.Handlers;

public class GetByContractServiceTimeQueryHandler : IRequestHandler<GetByContractServiceTimeQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetByContractServiceTimeQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(GetByContractServiceTimeQuery request, CancellationToken cancellationToken)
    {
        HashSet<ServiceTime> serviceTimes = new();
        var contract = await UnitOfWork.ContractRepository.GetFirstAsync(_ => _.Id.Equals(request.ContractId));
        if (contract is null)
            return new ErrorResult(Messages.ContractNotFound, Messages.ContractNotFoundId);

        foreach (var service in contract.ContractServices)
        {
            foreach (var serviceTime in service.ServiceTimes)
            {
                serviceTimes.Add(serviceTime);
            }
        }
        return !serviceTimes.Any()
            ? new ErrorResult(Messages.EmptyServiceTimeList, Messages.EmptyServiceTimeListId)
            : new SuccsessDataResult<IEnumerable<ServiceTime>>(serviceTimes, Messages.ServiceTimeListRetrieved, Messages.ServiceTimeListRetrievedId);
    }
}