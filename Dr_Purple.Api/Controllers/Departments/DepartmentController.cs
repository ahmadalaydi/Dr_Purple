using Dr_Purple.Api.Controllers.Base;
using Dr_Purple.Application.Services.DepartmentServices.Commands;
using Dr_Purple.Application.Services.DepartmentServices.Queries;
using Dr_Purple.Application.Utility.Paging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dr_Purple.Api.Controllers.Departments;
[AllowAnonymous]

public class DepartmentController : ApiController
{
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateDepartmentCommand([FromBody] CreateDepartmentCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpDelete]
    [Route("Delete")]
    public async Task<IActionResult> DeleteDepartmentCommand([FromQuery] long id)
        => Ok(await Mediator!.Send(new DeleteDepartmentCommand(id)));

    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> UpdateDepartmentCommand([FromQuery] long id, [FromBody] UpdateDepartmentCommand command)
        => Ok(await Mediator!.Send(command with { Id = id }));

    [HttpGet]
    [Route("All")]
    public async Task<IActionResult> GetAllDepartmentQuery([FromQuery] QueryOptions options)
    => Ok(await Mediator!.Send(new GetAllDepartmentQuery(options)));

    [HttpGet]
    [Route("Get")]
    public async Task<IActionResult> GetFirstDepartmentQuery([FromQuery] long id)
    => Ok(await Mediator!.Send(new GetFirstDepartmentQuery(id)));
}