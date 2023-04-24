using Dr_Purple.Application.Constants;
using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Services.MaterialServices.Commands;
using Dr_Purple.Application.Services.MaterialServices.Handlers.Commands.Base;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Application.Utility.Security;
using Dr_Purple.Domain.Entities.Users;
using MediatR;

namespace Dr_Purple.Application.Services.MaterialServices.Handlers.Commands;

public class CreateRangeMaterialCommandHandler : BaseMaterialCommandHandler,
    IRequestHandler<CreateRangeMaterialCommand, IDataResult<MaterialResponse>>
{
    public CreateRangeMaterialCommandHandler(IServiceProvider provider) : base(provider) { }

    public async Task<IDataResult<MaterialResponse>> Handle(CreateRangeMaterialCommand? command, CancellationToken cancellationToken)
    {
        await Task.WhenAll();
        HashingHelper.CreatePasswordHash(command!.Password!, out byte[] passwordHash, out byte[] passwordSalt);

        if (Repository!.GetSingleAsync(_ => _.UserName == command.UserName!) is not null)
            return new ErrorDataResult<MaterialResponse>(Messages.UserAlreadyExists, Messages.UserAlreadyExistsId);

        string? refreshToken = JwtTokenGenerator?.GenerateRefreshToken();
        _ = int.TryParse(Configuration!["JwtSettings:ExpiryDays"], out int expiryDays);

        var user = User.Create(
            command.FirstName!, command.LastName!, command.UserName!,
            command.ContactNumber!, command.AddressId,
            passwordSalt, passwordHash, command.Role, command.Gender,
            refreshToken, DateTime.UtcNow.AddDays(expiryDays));

        Repository.Add(user);
        await UnitOfWork!.SaveChangesAsync();

        string? accessToken = JwtTokenGenerator?.GenerateAccessToken(user);


        return new SuccsessDataResult<MaterialResponse>(new MaterialResponse(user,
            accessToken, refreshToken),
            Messages.UserRegistered, Messages.UserRegisteredId);
    }
}