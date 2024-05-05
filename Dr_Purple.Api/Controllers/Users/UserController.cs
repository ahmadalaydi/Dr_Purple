using Dr_Purple.Api.Controllers.Base;
using Dr_Purple.Application.Services.UserServices.Commands;
using Dr_Purple.Application.Services.UserServices.Queries;
using Dr_Purple.Application.Utility.Paging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dr_Purple.Api.Controllers.Users;
[AllowAnonymous]
public class UserController : ApiController
{
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateUserCommand([FromBody] CreateUserCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpDelete]
    [Route("Delete")]
    public async Task<IActionResult> DeleteUserCommand([FromQuery] long id)
        => Ok(await Mediator!.Send(new DeleteUserCommand(id)));

    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> UpdateUserCommand([FromQuery] long id, [FromBody] UpdateUserCommand command)
        => Ok(await Mediator!.Send(command with { Id = id }));

    [HttpPost]
    [Route("UploadProfilePic")]
    public async Task<IActionResult> UploadUserProfilePicCommand([FromQuery] long id, IFormFile profilePic)
        => Ok(await Mediator!.Send(new UploadUserProfilePicCommand() with { Id = id, ProfilePic = profilePic }));

    [HttpGet]
    [Route("All")]
    public async Task<IActionResult> GetAllUserQuery([FromQuery] QueryOptions options)
    => Ok(await Mediator!.Send(new GetAllUserQuery(options)));

    [HttpGet]
    [Route("Profile")]
    public async Task<IActionResult> GetFirstUserQuery([FromQuery] QueryOptions options)
    => Ok(await Mediator!.Send(new GetFirstUserQuery(options)));

}