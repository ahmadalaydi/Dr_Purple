using Dr_Purple.Api.Controllers.Base;
using Dr_Purple.Application.Services.AuthenticationServices.Commands;
using Dr_Purple.Application.Services.AuthenticationServices.Queries;
using Dr_Purple.Application.Services.UserServices.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dr_Purple.Api.Controllers.Users;
[AllowAnonymous]

public class AuthenticationController : ApiController
{
    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login([FromBody] LoginQuery query)
        => Ok(await Mediator!.Send(query));

    [HttpPost]
    [Route("RefreshToken")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPut]
    [Route("Verify")]
    public async Task<IActionResult> VerifyUserCommand([FromBody] VerifyUserCommand command)
    => Ok(await Mediator!.Send(command));

    [HttpPut]
    [Route("UpdateFCM_Key")]
    public async Task<IActionResult> UpdateUserFCM_KeyCommand([FromBody] UpdateUserFCM_KeyCommand command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("Logout")]
    public async Task<IActionResult> Logout()
    => Ok(await Mediator!.Send(new LogoutCommand()));
}