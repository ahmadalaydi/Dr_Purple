using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Files;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Users;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.UserServices.Commands.Handlers;
public class UploadUserProfilePicCommandHandler : IRequestHandler<UploadUserProfilePicCommand, IResult>
{
    private readonly IFileHelper FileHelper;
    private readonly IUnitOfWork UnitOfWork;
    public UploadUserProfilePicCommandHandler(IUnitOfWork unitOfWork, IFileHelper fileHelper)
    {
        UnitOfWork = unitOfWork;
        FileHelper = fileHelper;
    }

    public async Task<IResult> Handle(UploadUserProfilePicCommand command, CancellationToken cancellationToken)
    {
        var user = await UnitOfWork.UserRepository.GetFirstAsync(_ => _.Id == command.Id);
        if (user is null)
            return new ErrorResult(Messages.UserNotFound, Messages.UserNotFoundId);


        user.Update(FileHelper.Upload("Users\\Profiles\\", command.ProfilePic!));

        await UnitOfWork.UserRepository.UpdateAsync(user);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessDataResult<User>(user,
                    Messages.UserProfilePicUpdated,
                    Messages.UserProfilePicUpdatedId);

    }
}