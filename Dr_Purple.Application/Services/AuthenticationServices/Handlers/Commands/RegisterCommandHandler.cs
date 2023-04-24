using Dr_Purple.Application.Constants;
using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Services.AuthenticationServices.Commands;
using Dr_Purple.Application.Services.AuthenticationServices.Handlers.Commands.Base;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Application.Utility.Security;
using Dr_Purple.Domain.Entities.Users;
using MediatR;

namespace Dr_Purple.Application.Services.AuthenticationServices.Handlers.Commands;

public class RegisterCommandHandler : BaseAuthenticationCommandHandler,
    IRequestHandler<RegisterCommand, IDataResult<AuthenticationResponse>>
{
    public RegisterCommandHandler(IServiceProvider provider) : base(provider) { }

    public async Task<IDataResult<AuthenticationResponse>> Handle(RegisterCommand? command, CancellationToken cancellationToken)
    {
        await Task.WhenAll();
        HashingHelper.CreatePasswordHash(command!.Password!, out byte[] passwordHash, out byte[] passwordSalt);

        if (Repository!.GetSingleAsync(_ => _.UserName == command.UserName!) is not null)
            return new ErrorDataResult<AuthenticationResponse>(Messages.UserAlreadyExists, Messages.UserAlreadyExistsId);

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


        return new SuccsessDataResult<AuthenticationResponse>(
            new AuthenticationResponse(user,accessToken, refreshToken),
                                        Messages.UserRegistered,
                                        Messages.UserRegisteredId);
    }
}