using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Paging;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.ContractServices.Queries.Handlers;

public class GetAllContractQueryHandler : IRequestHandler<GetAllContractQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetAllContractQueryHandler(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }
    public async Task<IResult> Handle(GetAllContractQuery request, CancellationToken cancellationToken)
    {
        var Contracts = await Task.FromResult(UnitOfWork.ContractRepository.GetAll().Sort(request.Options.OrderBy).Search(request.Options.SearchBy).GetPaged(request.Options.PageNo, request.Options.PageSize));

        return Contracts.PageCount > 0
            ? new SuccsessDataResult<PagedResult<Contract>>(Contracts, Messages.ContractListRetrieved, Messages.ContractListRetrievedId)
            : new ErrorResult(Messages.EmptyContractList, Messages.EmptyContractListId);
    }
}