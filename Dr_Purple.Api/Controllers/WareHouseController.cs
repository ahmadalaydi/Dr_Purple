using Dr_Purple.Api.Controllers.Base;
using Dr_Purple.Application.Services.WareHouseServices.Commands;
using Dr_Purple.Application.Services.WareHouseServices.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dr_Purple.Api.Controllers;
[AllowAnonymous]
public class WareHouseController : ApiController
{
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateWareHouseCommand(CreateWareHouseCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("CreateRange")]
    public async Task<IActionResult> CreateRangeWareHouseCommand(CreateRangeWareHouseCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("Delete")]
    public async Task<IActionResult> DeleteWareHouseCommand(DeleteWareHouseCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("DeleteRange")]
    public async Task<IActionResult> DeleteRangeWareHouseCommand(DeleteRangeWareHouseCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("Update")]
    public async Task<IActionResult> UpdateWareHouseCommand(UpdateWareHouseCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("UpdateRange")]
    public async Task<IActionResult> UpdateRangeWareHouseCommand(UpdateRangeWareHouseCommand command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("Exists")]
    public async Task<IActionResult> ExistsWareHouseQuery(ExistsWareHouseQuery command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAllWareHouseQuery(GetAllWareHouseQuery command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("GetBy")]
    public async Task<IActionResult> GetByWareHouseQuery(GetByWareHouseQuery command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("GetFirst")]
    public async Task<IActionResult> GetFirstWareHouseQuery(GetFirstWareHouseQuery command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("GetSingle")]
    public async Task<IActionResult> GetSingleWareHouseQuery(GetSingleWareHouseQuery command)
    => Ok(await Mediator!.Send(command));
}