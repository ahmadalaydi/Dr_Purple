using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Paging;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.ContractServices.Queries.Handlers;

public class GetAllJobTitleQueryHandler : IRequestHandler<GetAllJobTitleQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetAllJobTitleQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(GetAllJobTitleQuery request, CancellationToken cancellationToken)
    {
        var JobTitles = await Task.FromResult(UnitOfWork.JobTitleRepository.GetAll().Sort(request.Options.OrderBy).Search(request.Options.SearchBy).GetPaged(request.Options.PageNo, request.Options.PageSize));

        return JobTitles.PageCount > 0
            ? new SuccsessDataResult<PagedResult<JobTitle>>(JobTitles, Messages.JobTitleListRetrieved, Messages.JobTitleListRetrievedId)
            : new ErrorResult(Messages.EmptyJobTitleList, Messages.EmptyJobTitleListId);
    }
}