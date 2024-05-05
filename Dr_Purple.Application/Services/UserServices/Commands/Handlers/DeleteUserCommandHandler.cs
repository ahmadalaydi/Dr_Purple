using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.UserServices.Commands.Handlers;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public DeleteUserCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;

    public async Task<IResult> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
    {
        var user = await UnitOfWork.UserRepository.GetFirstAsync(_ => _.Id == command.Id);
        if (user is null)
            return new ErrorResult(Messages.UserNotFound, Messages.UserNotFoundId);

        await UnitOfWork.UserRepository.DeleteAsync(user);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessResult(Messages.UserDeleted, Messages.UserDeletedId);
    }
}