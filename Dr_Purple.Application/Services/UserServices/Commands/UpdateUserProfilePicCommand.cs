using MediatR;
using Microsoft.AspNetCore.Http;

namespace Dr_Purple.Application.Services.UserServices.Commands;
public record UploadUserProfilePicCommand() : IRequest<Utility.Results.IResult>
{
    public long Id { get; init; }
    public IFormFile? ProfilePic { get; init; }
}