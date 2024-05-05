using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Paging;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Services;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.ServiceServices.Queries.Handlers;

public class GetAllServiceQueryHandler : IRequestHandler<GetAllServiceQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetAllServiceQueryHandler(IUnitOfWork unitOfWork) => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(GetAllServiceQuery request, CancellationToken cancellationToken)
    {
        var Services = await Task.FromResult(UnitOfWork.ServiceRepository.GetAll()
            .Sort(request.Options.OrderBy)
            .Search(request.Options.SearchBy)
            .GetPaged(request.Options.PageNo, request.Options.PageSize));

        return Services.PageCount > 0
            ? new SuccsessDataResult<PagedResult<Service>>(Services, Messages.ServiceListRetrieved, Messages.ServiceListRetrievedId)
            : new ErrorResult(Messages.EmptyServiceList, Messages.EmptyServiceListId);
    }
}