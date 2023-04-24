using Dr_Purple.Api.Controllers.Base;
using Dr_Purple.Application.Services.DepartmentServices.Commands;
using Dr_Purple.Application.Services.DepartmentServices.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dr_Purple.Api.Controllers;
[AllowAnonymous]
public class DepartmentController : ApiController
{
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateDepartmentCommand(CreateDepartmentCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("CreateRange")]
    public async Task<IActionResult> CreateRangeDepartmentCommand(CreateRangeDepartmentCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("Delete")]
    public async Task<IActionResult> DeleteDepartmentCommand(DeleteDepartmentCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("DeleteRange")]
    public async Task<IActionResult> DeleteRangeDepartmentCommand(DeleteRangeDepartmentCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("Update")]
    public async Task<IActionResult> UpdateDepartmentCommand(UpdateDepartmentCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("UpdateRange")]
    public async Task<IActionResult> UpdateRangeDepartmentCommand(UpdateRangeDepartmentCommand command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("Exists")]
    public async Task<IActionResult> ExistsDepartmentQuery(ExistsDepartmentQuery command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAllDepartmentQuery(GetAllDepartmentQuery command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("GetBy")]
    public async Task<IActionResult> GetByDepartmentQuery(GetByDepartmentQuery command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("GetFirst")]
    public async Task<IActionResult> GetFirstDepartmentQuery(GetFirstDepartmentQuery command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("GetSingle")]
    public async Task<IActionResult> GetSingleDepartmentQuery(GetSingleDepartmentQuery command)
    => Ok(await Mediator!.Send(command));
}