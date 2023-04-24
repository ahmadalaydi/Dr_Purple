using Dr_Purple.Application.Constants;
using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Services.WareHouseServices.Commands;
using Dr_Purple.Application.Services.WareHouseServices.Handlers.Commands.Base;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Application.Utility.Security;
using Dr_Purple.Domain.Entities.Users;
using MediatR;

namespace Dr_Purple.Application.Services.WareHouseServices.Handlers.Commands;

public class UpdateRangeWareHouseCommandHandler : BaseWareHouseCommandHandler,
    IRequestHandler<UpdateRangeWareHouseCommand, IDataResult<WareHouseResponse>>
{
    public UpdateRangeWareHouseCommandHandler(IServiceProvider provider) : base(provider) { }

    public async Task<IDataResult<WareHouseResponse>> Handle(UpdateRangeWareHouseCommand? command, CancellationToken cancellationToken)
    {
        await Task.WhenAll();
        HashingHelper.CreatePasswordHash(command!.Password!, out byte[] passwordHash, out byte[] passwordSalt);

        if (Repository!.GetSingleAsync(_ => _.UserName == command.UserName!) is not null)
            return new ErrorDataResult<WareHouseResponse>(Messages.UserAlreadyExists, Messages.UserAlreadyExistsId);

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


        return new SuccsessDataResult<WareHouseResponse>(new WareHouseResponse(user,
            accessToken, refreshToken),
            Messages.UserRegistered, Messages.UserRegisteredId);
    }
}