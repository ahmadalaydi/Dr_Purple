using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Paging;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Interfaces;
using MediatR;


namespace Dr_Purple.Application.Services.AttendServices.Queries.Handlers;

public class GetAllAttendQueryHandler : IRequestHandler<GetAllAttendQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetAllAttendQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(GetAllAttendQuery request, CancellationToken cancellationToken)
    {
        var Attends = await Task.FromResult(UnitOfWork.AttendRepository.GetAll().Sort(request.Options.OrderBy).Search(request.Options.SearchBy).GetPaged(request.Options.PageNo, request.Options.PageSize));

        return Attends.PageCount > 0
            ? new SuccsessDataResult<PagedResult<Attend>>(Attends, Messages.AttendListRetrieved, Messages.AttendListRetrievedId)
            : new ErrorResult(Messages.EmptyAttendList, Messages.EmptyAttendListId);
    }
}