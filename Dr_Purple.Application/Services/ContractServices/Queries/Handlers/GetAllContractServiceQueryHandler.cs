using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Paging;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.ContractServices.Queries.Handlers;

public class GetAllContractServiceQueryHandler : IRequestHandler<GetAllContractServiceQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetAllContractServiceQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(GetAllContractServiceQuery request, CancellationToken cancellationToken)
    {
        var ContractServices = await Task.FromResult(UnitOfWork.ContractServiceRepository.GetAll().Sort(request.Options.OrderBy).Search(request.Options.SearchBy).GetPaged(request.Options.PageNo, request.Options.PageSize));

        return ContractServices.PageCount > 0
            ? new SuccsessDataResult<PagedResult<ContractService>>(ContractServices, Messages.ContractServiceListRetrieved, Messages.ContractServiceListRetrievedId)
            : new ErrorResult(Messages.EmptyContractServiceList, Messages.EmptyContractServiceListId);
    }
}