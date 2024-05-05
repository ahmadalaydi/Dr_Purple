using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Paging;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Blogs;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.BlogServices.Queries.Handlers;

public class GetAllTagQueryHandler : IRequestHandler<GetAllTagQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetAllTagQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(GetAllTagQuery request, CancellationToken cancellationToken)
    {
        var Tags = await Task.FromResult(UnitOfWork.TagRepository.GetAll().Sort(request.Options.OrderBy).Search(request.Options.SearchBy).GetPaged(request.Options.PageNo, request.Options.PageSize));

        return Tags.PageCount > 0
            ? new SuccsessDataResult<PagedResult<Tag>>(Tags, Messages.TagListRetrieved, Messages.TagListRetrievedId)
            : new ErrorResult(Messages.EmptyTagList, Messages.EmptyTagListId);
    }
}