using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Services;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.ServiceServices.Queries.Handlers;

public class GetByServiceTimeQueryHandler : IRequestHandler<GetByServiceTimeQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetByServiceTimeQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(GetByServiceTimeQuery request, CancellationToken cancellationToken)
    {
        var ServiceTimes = await Task.FromResult(UnitOfWork.ServiceTimeRepository!
                                        .GetBy(_ => _.ServiceId == request.ServiceId));

        return !ServiceTimes.Any()
            ? new ErrorResult(Messages.EmptyServiceTimeList, Messages.EmptyServiceTimeListId)
            : new SuccsessDataResult<IEnumerable<ServiceTime>>(ServiceTimes, Messages.ServiceTimeListRetrieved, Messages.ServiceTimeListRetrievedId);
    }
}