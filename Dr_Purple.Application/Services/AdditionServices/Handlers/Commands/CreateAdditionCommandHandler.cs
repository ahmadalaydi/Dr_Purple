using Dr_Purple.Application.Constants;
using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Services.AdditionServices.Commands;
using Dr_Purple.Application.Services.AdditionServices.Handlers.Commands.Base;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Application.Utility.Security;
using Dr_Purple.Domain.Entities.Users;
using MediatR;

namespace Dr_Purple.Application.Services.AdditionServices.Handlers.Commands;

public class CreateAdditionCommandHandler : BaseAdditionCommandHandler,
    IRequestHandler<CreateAdditionCommand, IDataResult<AdditionResponse>>
{
    public CreateAdditionCommandHandler(IServiceProvider provider) : base(provider) { }

    public async Task<IDataResult<AdditionResponse>> Handle(CreateAdditionCommand? command, CancellationToken cancellationToken)
    {
        await Task.WhenAll();
        HashingHelper.CreatePasswordHash(command!.Password!, out byte[] passwordHash, out byte[] passwordSalt);

        if (Repository!.GetSingleAsync(_ => _.UserName == command.UserName!) is not null)
            return new ErrorDataResult<AdditionResponse>(Messages.UserAlreadyExists, Messages.UserAlreadyExistsId);

        string? refreshToken = JwtTokenGenerator?.GenerateRefreshToken();

        var user = User.Create(
            command.FirstName!, command.LastName!, command.UserName!,
            command.ContactNumber!, command.AddressId,
            passwordSalt, passwordHash, command.Role, command.Gender,
            refreshToken, DateTime.UtcNow.AddDays(expiryDays));

        Repository.Add(user);
        await UnitOfWork!.SaveChangesAsync();

        return new SuccsessDataResult<AdditionResponse>(new AdditionResponse(user),
            Messages.UserRegistered, Messages.UserRegisteredId);
    }
}