using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.BlogServices.Commands.Handlers;

public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public DeleteTagCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(DeleteTagCommand command, CancellationToken cancellationToken)
    {
        var Tag = await UnitOfWork.TagRepository.GetFirstAsync(_ => _.Id == command.Id);

        if (Tag is null)
            return new ErrorResult(Messages.TagNotFound, Messages.TagNotFoundId);

        await UnitOfWork.TagRepository.DeleteAsync(Tag);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessResult(Messages.TagDeleted, Messages.TagDeletedId);
    }
}