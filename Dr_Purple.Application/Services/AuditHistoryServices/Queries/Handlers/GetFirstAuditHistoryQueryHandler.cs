using Dr_Purple.Application.Constants.Messagess;

using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Auditing;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.AuditHistoryServices.Queries.Handlers;

public class GetFirstAuditHistoryQueryHandler : IRequestHandler<GetFirstAuditHistoryQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetFirstAuditHistoryQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(GetFirstAuditHistoryQuery request, CancellationToken cancellationToken)
    {
        var auditHistory = await UnitOfWork.AuditHistoryRepository.GetFirstAsync(_ => _.Id == request.Id);

        return auditHistory is null
            ? new ErrorResult(Messages.AuditHistoryNotFound, Messages.AuditHistoryNotFoundId)
            : new SuccsessDataResult<AuditHistory>(auditHistory, Messages.AuditHistoryExists, Messages.AuditHistoryExistsId);
    }
}