using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Application.Utility.Security;
using Dr_Purple.Domain.Entities.Users;
using Dr_Purple.Domain.Enums;
using Dr_Purple.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Dr_Purple.Application.Services.AuthenticationServices.Commands.Handlers;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    protected internal IJwtTokenGenerator JwtTokenGenerator;
    protected internal IConfiguration Configuration;
    public RegisterCommandHandler(IUnitOfWork unitOfWork, IJwtTokenGenerator jwtTokenGenerator, IConfiguration configuration)
    {
        UnitOfWork = unitOfWork;
        JwtTokenGenerator = jwtTokenGenerator;
        Configuration = configuration;
    }

    public async Task<IResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.WhenAll();
        HashingHelper.CreatePasswordHash(command.Password!, out byte[] passwordHash, out byte[] passwordSalt);

        string refreshToken = JwtTokenGenerator.GenerateRefreshToken();
        _ = int.TryParse(Configuration!["JwtSettings:ExpiryDays"], out int expiryDays);

        var user = User.Create(
            command.FirstName!, command.LastName!, command.UserName!,
            command.Email, command.ContactNumber!,
            passwordSalt, passwordHash, Role.Client, command.Gender,
            refreshToken, DateTime.UtcNow.AddDays(expiryDays));

        await UnitOfWork.UserRepository.AddAsync(user);
        await UnitOfWork.UserRepository.AddAsync(user);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessResult(Messages.UserRegistered,Messages.UserRegisteredId);
    }
}