using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Paging;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.AdditionServices.Queries.Handlers;

public class GetAllAdditionQueryHandler : IRequestHandler<GetAllAdditionQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetAllAdditionQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;

    public async Task<IResult> Handle(GetAllAdditionQuery request, CancellationToken cancellationToken)
    {
        var Additions = await Task.FromResult(UnitOfWork.AdditionRepository.GetAll().Search(request.Options.SearchBy).Sort(request.Options.OrderBy)
                                .GetPaged(request.Options.PageNo, request.Options.PageSize));

        return Additions.PageCount > 0
            ? new SuccsessDataResult<PagedResult<Addition>>(Additions, Messages.AdditionListRetrieved, Messages.AdditionListRetrievedId)
            : new ErrorResult(Messages.EmptyAdditionList, Messages.EmptyAdditionListId);
    }
}