using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Paging;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Works;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.WorkServices.Queries.Handlers;

public class GetAllWorkHoursExceptionQueryHandler : IRequestHandler<GetAllWorkHoursExceptionQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetAllWorkHoursExceptionQueryHandler(IUnitOfWork unitOfWork) => UnitOfWork = unitOfWork;

    public async Task<IResult> Handle(GetAllWorkHoursExceptionQuery request, CancellationToken cancellationToken)
    {
        var WorkHoursExceptions = await Task.FromResult(UnitOfWork.WorkHoursExceptionRepository.GetAll().Sort(request.Options.OrderBy).Search(request.Options.SearchBy).GetPaged(request.Options.PageNo, request.Options.PageSize));

        return WorkHoursExceptions.PageCount > 0
            ? new SuccsessDataResult<PagedResult<WorkHoursException>>(WorkHoursExceptions, Messages.WorkHoursExceptionListRetrieved, Messages.WorkHoursExceptionListRetrievedId)
            : new ErrorResult(Messages.EmptyWorkHoursExceptionList, Messages.EmptyWorkHoursExceptionListId);
    }
}