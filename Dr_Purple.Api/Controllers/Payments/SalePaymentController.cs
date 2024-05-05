using Dr_Purple.Api.Controllers.Base;
using Dr_Purple.Application.Services.PaymentServices.Commands;
using Dr_Purple.Application.Services.PaymentServices.Queries;
using Dr_Purple.Application.Utility.Paging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dr_Purple.Api.Controllers.Payments;
[AllowAnonymous]

public class SalePaymentController : ApiController
{
    [HttpPost]
    [Route("Approve")]
    public async Task<IActionResult> ApproveSalePaymentCommand([FromBody] ApproveSalePaymentCommand command)
    => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateSalePaymentCommand([FromBody] CreateSalePaymentCommand command)
    => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("Materials/Create")]
    public async Task<IActionResult> CreateSalePaymentMaterialCommand([FromBody] CreateSalePaymentItemCommand command)
    => Ok(await Mediator!.Send(command));

    [HttpDelete]
    [Route("Delete")]
    public async Task<IActionResult> DeleteSalePaymentCommand([FromQuery] Guid id)
    => Ok(await Mediator!.Send(new DeleteSalePaymentCommand(id)));

    [HttpDelete]
    [Route("Materials/Delete")]
    public async Task<IActionResult> DeleteSalePaymentMaterialCommand([FromQuery] DeleteSalePaymentItemCommand command)
    => Ok(await Mediator!.Send(command));

    [HttpPut]
    [Route("Materials/Update")]
    public async Task<IActionResult> UpdateSalePaymentMaterialCommand([FromBody] UpdateSalePaymentItemCommand command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("All")]
    public async Task<IActionResult> GetAllSalePaymentQuery([FromQuery] QueryOptions options)
    => Ok(await Mediator!.Send(new GetAllSalePaymentQuery(options)));

    [HttpGet]
    [Route("Materials/All")]
    public async Task<IActionResult> GetAllSalePaymentMaterialQuery([FromQuery] QueryOptions options)
    => Ok(await Mediator!.Send(new GetAllSalePaymentMaterialQuery(options)));

    [HttpGet]
    [Route("Get")]
    public async Task<IActionResult> GetFirstSalePaymentQuery([FromQuery] Guid id)
    => Ok(await Mediator!.Send(new GetFirstSalePaymentQuery(id)));
}