using Dr_Purple.Api.Controllers.Base;
using Dr_Purple.Application.Services.ContractServices.Commands;
using Dr_Purple.Application.Services.ContractServices.Queries;
using Dr_Purple.Application.Services.PaymentServices.Commands;
using Dr_Purple.Application.Services.ServiceServices.Queries;
using Dr_Purple.Application.Utility.Paging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Dr_Purple.Api.Controllers.Contracts;
[AllowAnonymous]

public class ContractController : ApiController
{
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateContractCommand([FromBody] CreateContractCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpDelete]
    [Route("Delete")]
    public async Task<IActionResult> DeleteContractCommand([FromQuery] long id)
        => Ok(await Mediator!.Send(new DeleteContractCommand(id)));

    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> UpdateContractCommand([FromQuery] long id, [FromBody] UpdateContractCommand command)
        => Ok(await Mediator!.Send(command with { Id = id }));

    [HttpPost]
    [Route("Activate")]
    public async Task<IActionResult> ActivateContractCommand([FromBody] ActivateContractCommand command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("All")]
    public async Task<IActionResult> GetAllContractQuery([FromQuery] QueryOptions options)
    => Ok(await Mediator!.Send(new GetAllContractQuery(options)));

    [HttpGet]
    [Route("Get")]
    public async Task<IActionResult> GetFirstContractQuery([FromQuery] long id)
    => Ok(await Mediator!.Send(new GetFirstContractQuery(id)));

    [HttpGet]
    [Route("ServiceTime/GetBy")]
    public async Task<IActionResult> GetByContractServiceTimeQuery([FromQuery] long ContractId)
   => Ok(await Mediator!.Send(new GetByContractServiceTimeQuery(ContractId)));

    //[HttpPost]
    //[Route("{ContractId}/CreateAddition")]
    //public async Task<IActionResult> CreateAdditionCommand([FromQuery] long ContractId, [FromBody] string? Name)
    //=> Ok(await Mediator!.Send(new CreateAdditionCommand(Name,ContractId)));

    //[HttpDelete]
    //[Route("{ContractId}/DeleteAddition")]
    //public async Task<IActionResult> DeleteAdditionCommand([FromQuery] long id)
    //    => Ok(await Mediator!.Send(new DeleteAdditionCommand(id)));

    //[HttpPut]
    //[Route("{ContractId}/UpdateAddition")]
    //public async Task<IActionResult> UpdateAdditionCommand([FromQuery] long id, [FromQuery] long ContractId, [FromBody] string? Name)
    //=> Ok(await Mediator!.Send(new UpdateAdditionCommand(Name,ContractId) with { Id = id }));
    ////TODO : Get additions by contractId

    //[HttpPost]
    //[Route("{ContractId}/CreateLeave")]
    //public async Task<IActionResult> CreateLeaveCommand([FromQuery] long ContractId, [FromBody] string? Name)
    //=> Ok(await Mediator!.Send(new CreateLeaveCommand(Name, ContractId)));

    //[HttpDelete]
    //[Route("{ContractId}/DeleteLeave")]
    //public async Task<IActionResult> DeleteLeaveCommand([FromQuery] long id)
    //=> Ok(await Mediator!.Send(new DeleteLeaveCommand(id)));

    //[HttpPut]
    //[Route("{ContractId}/UpdateLeave")]
    //public async Task<IActionResult> UpdateLeaveCommand([FromQuery] long id, [FromQuery] long ContractId, [FromBody] string? Name)
    //=> Ok(await Mediator!.Send(new UpdateLeaveCommand(Name, ContractId) with { Id = id }));
    ////TODO : Get Leaves by contractId

    //[HttpPut]
    //[Route("{ContractId}/UpdateJobTitle")]
    //public async Task<IActionResult> UpdateJobTitleCommand([FromQuery] long id, [FromQuery] long ContractId, [FromBody] string? Name)
    //=> Ok(await Mediator!.Send(new UpdateJobTitleCommand(Name, ContractId) with { Id = id }));
    ////TODO : Get JobTitles by contractId

}