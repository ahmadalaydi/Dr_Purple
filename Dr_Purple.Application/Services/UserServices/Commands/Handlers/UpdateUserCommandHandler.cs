using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Users;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.UserServices.Commands.Handlers;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public UpdateUserCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;

    public async Task<IResult> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var user = await UnitOfWork.UserRepository.GetFirstAsync(_ => _.Id == command.Id);
        if (user is null)
            return new ErrorResult(Messages.UserNotFound, Messages.UserNotFoundId);

        user.Update(command.FirstName, command.LastName!, command.UserName!, command.Email,
            command.ContactNumber, command.Address, command.Gender);

        await UnitOfWork.UserRepository.UpdateAsync(user);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessDataResult<User>(user, Messages.UserUpdated, Messages.UserUpdatedId);
    }
}