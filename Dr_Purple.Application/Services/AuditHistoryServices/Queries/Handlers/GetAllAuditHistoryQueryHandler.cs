using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Paging;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Auditing;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.AuditHistoryServices.Queries.Handlers;

public class GetAllAuditHistoryQueryHandler : IRequestHandler<GetAllAuditHistoryQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetAllAuditHistoryQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(GetAllAuditHistoryQuery request, CancellationToken cancellationToken)
    {
        var auditHistorys = await Task.FromResult(UnitOfWork.AuditHistoryRepository.GetAll().Sort(request.Options.OrderBy).Search(request.Options.SearchBy).GetPaged(request.Options.PageNo, request.Options.PageSize));

        return auditHistorys.PageCount > 0
            ? new SuccsessDataResult<PagedResult<AuditHistory>>(auditHistorys, Messages.AuditHistoryListRetrieved, Messages.AuditHistoryListRetrievedId)
            : new ErrorResult(Messages.EmptyAuditHistoryList, Messages.EmptyAuditHistoryListId);
    }
}