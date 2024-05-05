using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Paging;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Works;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.WorkServices.Queries.Handlers;

public class GetAllHolidayQueryHandler : IRequestHandler<GetAllHolidayQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetAllHolidayQueryHandler(IUnitOfWork unitOfWork) => UnitOfWork = unitOfWork;

    public async Task<IResult> Handle(GetAllHolidayQuery request, CancellationToken cancellationToken)
    {
        var Holidays = await Task.FromResult(UnitOfWork.HolidayRepository.GetAll().Sort(request.Options.OrderBy).Search(request.Options.SearchBy).GetPaged(request.Options.PageNo, request.Options.PageSize));

        return Holidays.PageCount > 0
            ? new SuccsessDataResult<PagedResult<Holiday>>(Holidays, Messages.HolidayListRetrieved, Messages.HolidayListRetrievedId)
            : new ErrorResult(Messages.EmptyHolidayList, Messages.EmptyHolidayListId);
    }
}