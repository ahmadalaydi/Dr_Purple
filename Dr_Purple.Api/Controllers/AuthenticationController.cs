using Dr_Purple.Api.Controllers.Base;
using Dr_Purple.Application.Services.AuthenticationServices.Commands;
using Dr_Purple.Application.Services.AuthenticationServices.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dr_Purple.Api.Controllers;
[AllowAnonymous]
public class AuthenticationController : ApiController
{

    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register(RegisterCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login(LoginQuery query)
        => Ok(await Mediator!.Send(query));
}