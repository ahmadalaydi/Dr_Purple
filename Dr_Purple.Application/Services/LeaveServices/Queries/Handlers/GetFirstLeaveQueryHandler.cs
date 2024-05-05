using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.LeaveServices.Queries.Handlers;

public class GetFirstLeaveQueryHandler : IRequestHandler<GetFirstLeaveQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetFirstLeaveQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(GetFirstLeaveQuery request, CancellationToken cancellationToken)
    {
        var leave = await UnitOfWork.LeaveRepository.GetFirstAsync(_ => _.Id == request.Id);

        return leave is null
            ? new ErrorResult(Messages.LeaveNotFound, Messages.LeaveNotFoundId)
            : new SuccsessDataResult<Leave>(leave, Messages.LeaveExists, Messages.LeaveExistsId);
    }
}