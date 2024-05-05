using Dr_Purple.Api.Controllers.Base;
using Dr_Purple.Application.Services.AdditionServices.Commands;
using Dr_Purple.Application.Services.AdditionServices.Queries;
using Dr_Purple.Application.Utility.Paging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dr_Purple.Api.Controllers.Contracts;
[AllowAnonymous]
public class AdditionController : ApiController
{
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateAdditionCommand([FromBody] CreateAdditionCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpDelete]
    [Route("Delete")]
    public async Task<IActionResult> DeleteAdditionCommand([FromQuery] long id)
        => Ok(await Mediator!.Send(new DeleteAdditionCommand(id)));

    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> UpdateAdditionCommand([FromQuery] long id, [FromBody] UpdateAdditionCommand command)
        => Ok(await Mediator!.Send(command with { Id = id }));

    [HttpGet]
    [Route("All")]
    public async Task<IActionResult> GetAllAdditionQuery([FromQuery] QueryOptions options)
    => Ok(await Mediator!.Send(new GetAllAdditionQuery(options)));


    [HttpGet]
    [Route("Get")]
    public async Task<IActionResult> GetFirstAdditionQuery([FromQuery] long id)
    => Ok(await Mediator!.Send(new GetFirstAdditionQuery(id)));
}