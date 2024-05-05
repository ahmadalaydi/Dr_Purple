using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Blogs;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.BlogServices.Commands.Handlers;

public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public CreateTagCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(CreateTagCommand command, CancellationToken cancellationToken)
    {
        var tag = Tag.Create(command.Name);
        await UnitOfWork.TagRepository.AddAsync(tag);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessDataResult<Tag>(tag, Messages.TagCreated, Messages.TagCreatedId);
    }
}