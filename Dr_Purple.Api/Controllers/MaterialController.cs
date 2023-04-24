using Dr_Purple.Api.Controllers.Base;
using Dr_Purple.Application.Services.MaterialServices.Commands;
using Dr_Purple.Application.Services.MaterialServices.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dr_Purple.Api.Controllers;
[AllowAnonymous]
public class MaterialController : ApiController
{
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateMaterialCommand(CreateMaterialCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("CreateRange")]
    public async Task<IActionResult> CreateRangeMaterialCommand(CreateRangeMaterialCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("Delete")]
    public async Task<IActionResult> DeleteMaterialCommand(DeleteMaterialCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("DeleteRange")]
    public async Task<IActionResult> DeleteRangeMaterialCommand(DeleteRangeMaterialCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("Update")]
    public async Task<IActionResult> UpdateMaterialCommand(UpdateMaterialCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("UpdateRange")]
    public async Task<IActionResult> UpdateRangeMaterialCommand(UpdateRangeMaterialCommand command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("Exists")]
    public async Task<IActionResult> ExistsMaterialQuery(ExistsMaterialQuery command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAllMaterialQuery(GetAllMaterialQuery command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("GetBy")]
    public async Task<IActionResult> GetByMaterialQuery(GetByMaterialQuery command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("GetFirst")]
    public async Task<IActionResult> GetFirstMaterialQuery(GetFirstMaterialQuery command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("GetSingle")]
    public async Task<IActionResult> GetSingleMaterialQuery(GetSingleMaterialQuery command)
    => Ok(await Mediator!.Send(command));
}