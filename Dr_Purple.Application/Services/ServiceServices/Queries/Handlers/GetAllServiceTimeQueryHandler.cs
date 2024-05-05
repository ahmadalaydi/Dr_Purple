using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Paging;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Services;
using Dr_Purple.Domain.Entities.Services.State;
using Dr_Purple.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dr_Purple.Application.Services.ServiceServices.Queries.Handlers;

public class GetAllServiceTimeQueryHandler : IRequestHandler<GetAllServiceTimeQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetAllServiceTimeQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(GetAllServiceTimeQuery request, CancellationToken cancellationToken)
    {
        var ServiceTimes = await Task.FromResult(UnitOfWork.ServiceTimeRepository
            .GetBy(_=>_.State == new FreeServiceTimeState())
            .Sort(request.Options.OrderBy)
            .Search(request.Options.SearchBy)
            .GetPaged(request.Options.PageNo, request.Options.PageSize));

        return ServiceTimes.PageCount > 0
            ? new SuccsessDataResult<PagedResult<ServiceTime>>(ServiceTimes, Messages.ServiceTimeListRetrieved, Messages.ServiceTimeListRetrievedId)
            : new ErrorResult(Messages.EmptyServiceTimeList, Messages.EmptyServiceTimeListId);
    }
}