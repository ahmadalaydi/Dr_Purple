using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Works;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.WorkServices.Queries.Handlers;

public class GetFirstHolidayQueryHandler : IRequestHandler<GetFirstHolidayQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetFirstHolidayQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;

    public async Task<IResult> Handle(GetFirstHolidayQuery request, CancellationToken cancellationToken)
    {
        var holiday = await UnitOfWork.HolidayRepository.GetFirstAsync(_ => _.Id == request.Id);

        return holiday is null
            ? new ErrorResult(Messages.HolidayNotFound, Messages.HolidayNotFoundId)
            : new SuccsessDataResult<Holiday>(holiday, Messages.HolidayExists, Messages.HolidayExistsId);
    }
}