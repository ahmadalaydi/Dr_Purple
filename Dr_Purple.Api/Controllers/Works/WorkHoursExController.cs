using Dr_Purple.Api.Controllers.Base;
using Dr_Purple.Application.Services.WorkServices.Commands;
using Dr_Purple.Application.Services.WorkServices.Queries;
using Dr_Purple.Application.Utility.Paging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Dr_Purple.Api.Controllers.Works;
[AllowAnonymous]

public class WorkHoursExceptionController : ApiController
{
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateWorkHoursExceptionCommand([FromBody] CreateWorkHoursExceptionCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpDelete]
    [Route("Delete")]
    public async Task<IActionResult> DeleteWorkHoursExceptionCommand([FromQuery] long id)
        => Ok(await Mediator!.Send(new DeleteWorkHoursExceptionCommand(id)));

    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> UpdateWorkHoursExceptionCommand([FromQuery] long id, [FromBody] UpdateWorkHoursExceptionCommand command)
        => Ok(await Mediator!.Send(command with { Id = id }));

    [HttpGet]
    [Route("All")]
    public async Task<IActionResult> GetAllWorkHoursExceptionQuery([FromQuery] QueryOptions options)
    => Ok(await Mediator!.Send(new GetAllWorkHoursExceptionQuery(options)));

    [HttpGet]
    [Route("Get")]
    public async Task<IActionResult> GetFirstWorkHoursExceptionQuery([FromQuery] long id)
    => Ok(await Mediator!.Send(new GetFirstWorkHoursExceptionQuery(id)));
}