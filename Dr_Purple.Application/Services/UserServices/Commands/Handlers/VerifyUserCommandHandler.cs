using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Application.Utility.Security;
using Dr_Purple.Domain.Entities.Users;
using Dr_Purple.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Dr_Purple.Application.Services.UserServices.Commands.Handlers;

public class VerifyUserCommandHandler : IRequestHandler<VerifyUserCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public VerifyUserCommandHandler(IUnitOfWork unitOfWork)
       => UnitOfWork = unitOfWork;

    public async Task<IResult> Handle(VerifyUserCommand command, CancellationToken cancellationToken)
    {
        var user = await UnitOfWork.UserRepository.GetFirstAsync(_=>_.ContactNumber.Equals(command.ContactNumber));
        if (user is null)
            return new ErrorResult(Messages.UserNotFound, Messages.UserNotFoundId);

        user.Verify();

        await UnitOfWork.UserRepository.UpdateAsync(user);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessResult(Messages.UserUpdated, Messages.UserUpdatedId);
    }
}