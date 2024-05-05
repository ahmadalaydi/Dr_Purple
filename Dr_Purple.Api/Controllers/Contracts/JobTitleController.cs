using Dr_Purple.Api.Controllers.Base;
using Dr_Purple.Application.Services.ContractServices.Commands;
using Dr_Purple.Application.Services.ContractServices.Queries;
using Dr_Purple.Application.Utility.Paging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dr_Purple.Api.Controllers.Contracts;
[AllowAnonymous]

public class JobTitleController : ApiController
{
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateJobTitleCommand([FromBody] CreateJobTitleCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpDelete]
    [Route("Delete")]
    public async Task<IActionResult> DeleteJobTitleCommand([FromQuery] long id)
        => Ok(await Mediator!.Send(new DeleteJobTitleCommand(id)));

    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> UpdateJobTitleCommand([FromQuery] long id, [FromBody] UpdateJobTitleCommand command)
        => Ok(await Mediator!.Send(command with { Id = id }));

    [HttpGet]
    [Route("All")]
    public async Task<IActionResult> GetAllJobTitleQuery([FromQuery] QueryOptions options)
    => Ok(await Mediator!.Send(new GetAllJobTitleQuery(options)));


    [HttpGet]
    [Route("Get")]
    public async Task<IActionResult> GetFirstJobTitleQuery([FromQuery] long id)
    => Ok(await Mediator!.Send(new GetFirstJobTitleQuery(id)));
}