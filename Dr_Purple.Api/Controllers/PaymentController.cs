using Dr_Purple.Api.Controllers.Base;
using Dr_Purple.Application.Services.PaymentServices.Commands;
using Dr_Purple.Application.Services.PaymentServices.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dr_Purple.Api.Controllers;
[AllowAnonymous]
public class PaymentController : ApiController
{
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreatePaymentCommand(CreatePaymentCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("CreateRange")]
    public async Task<IActionResult> CreateRangePaymentCommand(CreateRangePaymentCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("Delete")]
    public async Task<IActionResult> DeletePaymentCommand(DeletePaymentCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("DeleteRange")]
    public async Task<IActionResult> DeleteRangePaymentCommand(DeleteRangePaymentCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("Update")]
    public async Task<IActionResult> UpdatePaymentCommand(UpdatePaymentCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("UpdateRange")]
    public async Task<IActionResult> UpdateRangePaymentCommand(UpdateRangePaymentCommand command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("Exists")]
    public async Task<IActionResult> ExistsPaymentQuery(ExistsPaymentQuery command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAllPaymentQuery(GetAllPaymentQuery command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("GetBy")]
    public async Task<IActionResult> GetByPaymentQuery(GetByPaymentQuery command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("GetFirst")]
    public async Task<IActionResult> GetFirstPaymentQuery(GetFirstPaymentQuery command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("GetSingle")]
    public async Task<IActionResult> GetSinglePaymentQuery(GetSinglePaymentQuery command)
    => Ok(await Mediator!.Send(command));
}