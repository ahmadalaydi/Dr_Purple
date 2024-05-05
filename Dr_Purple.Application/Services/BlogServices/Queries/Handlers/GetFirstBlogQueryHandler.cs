using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Blogs;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.BlogServices.Queries.Handlers;

public class GetFirstBlogQueryHandler : IRequestHandler<GetFirstBlogQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetFirstBlogQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(GetFirstBlogQuery request, CancellationToken cancellationToken)
    {
        var blog = await UnitOfWork.BlogRepository.GetFirstAsync(_ => _.Id == request.Id);

        return blog is null
            ? new ErrorResult(Messages.BlogNotFound, Messages.BlogNotFoundId)
            : new SuccsessDataResult<Blog>(blog, Messages.BlogExists, Messages.BlogExistsId);
    }
}