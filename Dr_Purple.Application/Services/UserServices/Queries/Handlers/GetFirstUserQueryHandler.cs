using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Users;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.UserServices.Queries.Handlers;

public class GetFirstUserQueryHandler : IRequestHandler<GetFirstUserQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    protected internal IAuthenticatedUserService AuthenticatedUserService;
    public GetFirstUserQueryHandler(IUnitOfWork unitOfWork, IAuthenticatedUserService authenticatedUserService)
    {
        UnitOfWork = unitOfWork;
        AuthenticatedUserService = authenticatedUserService;
    }

    public async Task<IResult> Handle(GetFirstUserQuery request, CancellationToken cancellationToken)
    {
        var user = await UnitOfWork.UserRepository.GetFirstAsync(_ => _.Id.Equals(long.Parse(AuthenticatedUserService.UserId!)));

        return user is null
            ? new ErrorResult(Messages.UserNotFound, Messages.UserNotFoundId)
            : new SuccsessDataResult<User>(user, Messages.UserExists, Messages.UserExistsId);
    }
}