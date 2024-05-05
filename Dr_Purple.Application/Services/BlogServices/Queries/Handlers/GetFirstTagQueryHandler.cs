using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Blogs;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.BlogServices.Queries.Handlers;

public class GetFirstTagQueryHandler : IRequestHandler<GetFirstTagQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetFirstTagQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(GetFirstTagQuery request, CancellationToken cancellationToken)
    {
        var tag = await UnitOfWork.TagRepository.GetFirstAsync(_ => _.Id == request.Id);

        return tag is null
            ? new ErrorResult(Messages.TagNotFound, Messages.TagNotFoundId)
            : new SuccsessDataResult<Tag>(tag, Messages.TagExists, Messages.TagExistsId);
    }
}