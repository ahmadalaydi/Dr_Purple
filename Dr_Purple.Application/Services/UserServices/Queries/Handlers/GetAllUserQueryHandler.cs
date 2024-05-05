using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Paging;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Users;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.UserServices.Queries.Handlers;

public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetAllUserQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;

    public async Task<IResult> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
    {
        var users = await Task.FromResult(UnitOfWork.UserRepository.GetAll().Sort(request.Options.OrderBy).Search(request.Options.SearchBy).GetPaged(request.Options.PageNo, request.Options.PageSize));

        return users.PageCount > 0
            ? new SuccsessDataResult<PagedResult<User>>(users, Messages.UserListRetrieved, Messages.UserListRetrievedId)
            : new ErrorResult(Messages.EmptyUserList, Messages.EmptyUserListId);
    }
}