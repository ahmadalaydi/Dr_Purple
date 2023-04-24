using Dr_Purple.Api.Controllers.Base;
using Dr_Purple.Application.Services.AdditionServices.Commands;
using Dr_Purple.Application.Services.AdditionServices.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dr_Purple.Api.Controllers;
[AllowAnonymous]
public class AdditionController : ApiController
{
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateAdditionCommand(CreateAdditionCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("CreateRange")]
    public async Task<IActionResult> CreateRangeAdditionCommand(CreateRangeAdditionCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("Delete")]
    public async Task<IActionResult> DeleteAdditionCommand(DeleteAdditionCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("DeleteRange")]
    public async Task<IActionResult> DeleteRangeAdditionCommand(DeleteRangeAdditionCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("Update")]
    public async Task<IActionResult> UpdateAdditionCommand(UpdateAdditionCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("UpdateRange")]
    public async Task<IActionResult> UpdateRangeAdditionCommand(UpdateRangeAdditionCommand command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("Exists")]
    public async Task<IActionResult> ExistsAdditionQuery(ExistsAdditionQuery command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAllAdditionQuery(GetAllAdditionQuery command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("GetBy")]
    public async Task<IActionResult> GetByAdditionQuery(GetByAdditionQuery command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("GetFirst")]
    public async Task<IActionResult> GetFirstAdditionQuery(GetFirstAdditionQuery command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("GetSingle")]
    public async Task<IActionResult> GetSingleAdditionQuery(GetSingleAdditionQuery command)
    => Ok(await Mediator!.Send(command));
}