using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Blogs;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.BlogServices.Commands.Handlers;

public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public UpdateTagCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(UpdateTagCommand command, CancellationToken cancellationToken)
    {
        var tag = await UnitOfWork.TagRepository.GetFirstAsync(_ => _.Id == command.Id);
        if (tag is null)
            return new ErrorResult(Messages.TagNotFound, Messages.TagNotFoundId);

        tag!.Update(command.Name);
        await UnitOfWork.TagRepository.UpdateAsync(tag);
        await UnitOfWork.SaveChangesAsync();
        return new SuccsessDataResult<Tag>(tag, Messages.TagUpdated, Messages.TagUpdatedId);
    }
}