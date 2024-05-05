using Dr_Purple.Api.Controllers.Base;
using Dr_Purple.Application.Services.MaterialServices.Commands;
using Dr_Purple.Application.Services.MaterialServices.Queries;
using Dr_Purple.Application.Utility.Paging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dr_Purple.Api.Controllers.Materials;
[AllowAnonymous]

public class NotForSaleMaterialController : ApiController
{
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateMaterialCommand([FromBody] CreateNotForSaleMaterialCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpDelete]
    [Route("Delete")]
    public async Task<IActionResult> DeleteMaterialCommand([FromQuery] long id)
        => Ok(await Mediator!.Send(new DeleteNotForSaleMaterialCommand(id)));

    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> UpdateMaterialCommand([FromQuery] long id, [FromBody] UpdateNotForSaleMaterialCommand command)
        => Ok(await Mediator!.Send(command with { Id = id }));

    [HttpGet]
    [Route("All")]
    public async Task<IActionResult> GetAllMaterialQuery([FromQuery] QueryOptions options)
    => Ok(await Mediator!.Send(new GetAllNotForSaleMaterialQuery(options)));

    [HttpGet]
    [Route("Get")]
    public async Task<IActionResult> GetFirstMaterialQuery([FromQuery] long id)
    => Ok(await Mediator!.Send(new GetFirstNotForSaleMaterialQuery(id)));
}