using Dr_Purple.Api.Controllers.Base;
using Dr_Purple.Application.Services.SubDepartmentServices.Commands;
using Dr_Purple.Application.Services.SubDepartmentServices.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dr_Purple.Api.Controllers;
[AllowAnonymous]
public class SubDepartmentController : ApiController
{
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateSubDepartmentCommand(CreateSubDepartmentCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("CreateRange")]
    public async Task<IActionResult> CreateRangeSubDepartmentCommand(CreateRangeSubDepartmentCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("Delete")]
    public async Task<IActionResult> DeleteSubDepartmentCommand(DeleteSubDepartmentCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("DeleteRange")]
    public async Task<IActionResult> DeleteRangeSubDepartmentCommand(DeleteRangeSubDepartmentCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("Update")]
    public async Task<IActionResult> UpdateSubDepartmentCommand(UpdateSubDepartmentCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("UpdateRange")]
    public async Task<IActionResult> UpdateRangeSubDepartmentCommand(UpdateRangeSubDepartmentCommand command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("Exists")]
    public async Task<IActionResult> ExistsSubDepartmentQuery(ExistsSubDepartmentQuery command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAllSubDepartmentQuery(GetAllSubDepartmentQuery command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("GetBy")]
    public async Task<IActionResult> GetBySubDepartmentQuery(GetBySubDepartmentQuery command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("GetFirst")]
    public async Task<IActionResult> GetFirstSubDepartmentQuery(GetFirstSubDepartmentQuery command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("GetSingle")]
    public async Task<IActionResult> GetSingleSubDepartmentQuery(GetSingleSubDepartmentQuery command)
    => Ok(await Mediator!.Send(command));
}