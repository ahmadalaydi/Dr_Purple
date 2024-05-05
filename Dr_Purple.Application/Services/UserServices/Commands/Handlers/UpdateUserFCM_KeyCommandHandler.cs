using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Application.Utility.Security;
using Dr_Purple.Domain.Entities.Users;
using Dr_Purple.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Dr_Purple.Application.Services.UserServices.Commands.Handlers;

public class UpdateUserFCM_KeyCommandHandler : IRequestHandler<UpdateUserFCM_KeyCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    protected internal IAuthenticatedUserService AuthenticatedUserService;
    public UpdateUserFCM_KeyCommandHandler(IUnitOfWork unitOfWork, IAuthenticatedUserService authenticatedUserService)
    {
        UnitOfWork = unitOfWork;
        AuthenticatedUserService = authenticatedUserService;
    }

    public async Task<IResult> Handle(UpdateUserFCM_KeyCommand command, CancellationToken cancellationToken)
    {
        var user = await UnitOfWork.UserRepository.GetFirstAsync(_=>_.Id.Equals(long.Parse(AuthenticatedUserService.UserId!)));
        if (user is null)
            return new ErrorResult(Messages.UserNotFound, Messages.UserNotFoundId);

        user.UpdateFCM_Key(command.FCM_Key);

        await UnitOfWork.UserRepository.UpdateAsync(user);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessResult(Messages.UserUpdated, Messages.UserUpdatedId);
    }
}