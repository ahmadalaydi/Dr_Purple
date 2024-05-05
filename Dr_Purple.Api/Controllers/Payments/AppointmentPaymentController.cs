using Dr_Purple.Api.Controllers.Base;
using Dr_Purple.Application.Services.PaymentServices.Commands;
using Dr_Purple.Application.Services.PaymentServices.Queries;
using Dr_Purple.Application.Utility.Paging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dr_Purple.Api.Controllers.Payments;
[AllowAnonymous]

public class AppointmentPaymentController : ApiController
{
    [HttpPost]
    [Route("Approve")]
    public async Task<IActionResult> ApproveAppointmentPaymentCommand([FromBody] ApproveAppointmentPaymentCommand command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("All")]
    public async Task<IActionResult> GetAllAppointmentPaymentQuery([FromQuery] QueryOptions options)
    => Ok(await Mediator!.Send(new GetAllAppointmentPaymentQuery(options)));

    [HttpGet]
    [Route("Get")]
    public async Task<IActionResult> GetFirstAppointmentPaymentQuery([FromQuery] Guid id)
    => Ok(await Mediator!.Send(new GetFirstAppointmentPaymentQuery(id)));
}