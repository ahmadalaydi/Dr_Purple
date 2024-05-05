using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.BlogServices.Commands.Handlers;

public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public DeleteBlogCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(DeleteBlogCommand command, CancellationToken cancellationToken)
    {
        var Blog = await UnitOfWork.BlogRepository.GetFirstAsync(_ => _.Id == command.Id);

        if (Blog is null)
            return new ErrorResult(Messages.BlogNotFound, Messages.BlogNotFoundId);

        await UnitOfWork.BlogRepository.DeleteAsync(Blog);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessResult(Messages.BlogDeleted, Messages.BlogDeletedId);
    }
}