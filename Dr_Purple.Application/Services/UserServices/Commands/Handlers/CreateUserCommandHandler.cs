using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Application.Utility.Security;
using Dr_Purple.Domain.Entities.Users;
using Dr_Purple.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Dr_Purple.Application.Services.UserServices.Commands.Handlers;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, IResult>
{
    protected internal IJwtTokenGenerator JwtTokenGenerator;
    protected internal IConfiguration Configuration;
    private readonly IUnitOfWork UnitOfWork;
    public CreateUserCommandHandler(IUnitOfWork unitOfWork, IJwtTokenGenerator jwtTokenGenerator, IConfiguration configuration)
    {
        UnitOfWork = unitOfWork;
        JwtTokenGenerator = jwtTokenGenerator;
        Configuration = configuration;
    }

    public async Task<IResult> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        HashingHelper.CreatePasswordHash(command.Password!, out byte[] passwordHash, out byte[] passwordSalt);

        string refreshToken = JwtTokenGenerator.GenerateRefreshToken();
        _ = int.TryParse(Configuration!["JwtSettings:ExpiryDays"], out int expiryDays);

        var user = User.Create(
            command.FirstName!, command.LastName, command.UserName,
            command.Email, command.ContactNumber,
            passwordSalt, passwordHash, command.Role, command.Gender,
            refreshToken, DateTime.UtcNow.AddDays(expiryDays));

        await UnitOfWork.UserRepository.AddAsync(user);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessDataResult<User>(user, Messages.UserCreated, Messages.UserCreatedId);
    }
}