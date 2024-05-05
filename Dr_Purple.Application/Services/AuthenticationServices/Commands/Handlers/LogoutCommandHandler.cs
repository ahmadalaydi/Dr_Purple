using Dr_Purple.Application.Constants.Messagess;

using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.AuthenticationServices.Commands.Handlers;

public class LogoutCommandHandler : IRequestHandler<LogoutCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    protected internal IAuthenticatedUserService AuthenticatedUserService;
    public LogoutCommandHandler(IUnitOfWork unitOfWork, IAuthenticatedUserService authenticatedUserService)
    {
        UnitOfWork = unitOfWork;
        AuthenticatedUserService = authenticatedUserService;
    }
    public async Task<IResult> Handle(LogoutCommand command, CancellationToken cancellationToken)
    {
        var user = await UnitOfWork.UserRepository.GetFirstAsync(_ => _.Id == long.Parse(AuthenticatedUserService.UserId!));
        if (user is null)
        {
            return new ErrorResult(Messages.UserNotFound, Messages.UserNotFoundId);
        }

        user.Logout();
        await UnitOfWork.UserRepository.UpdateAsync(user);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessResult(Messages.UserLogedout, Messages.UserLogedoutId);
    }
}