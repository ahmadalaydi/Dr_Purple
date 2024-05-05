using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Paging;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Blogs;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.BlogServices.Queries.Handlers;

public class GetAllBlogQueryHandler : IRequestHandler<GetAllBlogQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetAllBlogQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(GetAllBlogQuery request, CancellationToken cancellationToken)
    {
        var Blogs = await Task.FromResult(UnitOfWork.BlogRepository.GetAll().Sort(request.Options.OrderBy).Search(request.Options.SearchBy).GetPaged(request.Options.PageNo, request.Options.PageSize));

        return Blogs.PageCount > 0
            ? new SuccsessDataResult<PagedResult<Blog>>(Blogs, Messages.BlogListRetrieved, Messages.BlogListRetrievedId)
            : new ErrorResult(Messages.EmptyBlogList, Messages.EmptyBlogListId);
    }
}