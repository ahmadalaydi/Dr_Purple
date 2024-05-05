using Dr_Purple.Api.Controllers.Base;
using Dr_Purple.Application.Services.ContractServices.Commands;
using Dr_Purple.Application.Services.ContractServices.Queries;
using Dr_Purple.Application.Utility.Paging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dr_Purple.Api.Controllers.Contracts;
[AllowAnonymous]

public class ContractServiceController : ApiController
{
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateContractServiceCommand([FromBody] CreateContractServiceCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpDelete]
    [Route("Delete")]
    public async Task<IActionResult> DeleteContractServiceCommand([FromQuery] long id)
        => Ok(await Mediator!.Send(new DeleteContractServiceCommand(id)));

    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> UpdateContractServiceCommand([FromQuery] long id, [FromBody] UpdateContractServiceCommand command)
        => Ok(await Mediator!.Send(command with { Id = id }));

    [HttpGet]
    [Route("All")]
    public async Task<IActionResult> GetAllContractServiceQuery([FromQuery] QueryOptions options)
    => Ok(await Mediator!.Send(new GetAllContractServiceQuery(options)));


    [HttpGet]
    [Route("Get")]
    public async Task<IActionResult> GetFirstContractServiceQuery([FromQuery] long id)
    => Ok(await Mediator!.Send(new GetFirstContractServiceQuery(id)));
}