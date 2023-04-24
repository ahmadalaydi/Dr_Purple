using Dr_Purple.Application.Constants;
using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Services.ServiceServices.Commands;
using Dr_Purple.Application.Services.ServiceServices.Handlers.Commands.Base;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Application.Utility.Security;
using Dr_Purple.Domain.Entities.Users;
using MediatR;

namespace Dr_Purple.Application.Services.ServiceServices.Handlers.Commands;

public class DeleteRangeServiceCommandHandler : BaseServiceCommandHandler,
    IRequestHandler<DeleteRangeServiceCommand, IDataResult<ServiceResponse>>
{
    public DeleteRangeServiceCommandHandler(IServiceProvider provider) : base(provider) { }

    public async Task<IDataResult<ServiceResponse>> Handle(DeleteRangeServiceCommand? command, CancellationToken cancellationToken)
    {
        await Task.WhenAll();
        HashingHelper.CreatePasswordHash(command!.Password!, out byte[] passwordHash, out byte[] passwordSalt);

        if (Repository!.GetSingleAsync(_ => _.UserName == command.UserName!) is not null)
            return new ErrorDataResult<ServiceResponse>(Messages.UserAlreadyExists, Messages.UserAlreadyExistsId);

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


        return new SuccsessDataResult<ServiceResponse>(new ServiceResponse(user,
            accessToken, refreshToken),
            Messages.UserRegistered, Messages.UserRegisteredId);
    }
}