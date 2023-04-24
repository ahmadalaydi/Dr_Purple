using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dr_Purple.Api.Controllers.Base;

[Authorize]
[ApiController]
public abstract class ApiController : ControllerBase
{
    private IMediator? _mediator;
    protected IMediator? Mediator
        => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
}