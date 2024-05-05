using Dr_Purple.Api.Controllers.Base;
using Dr_Purple.Application.Services.PaymentServices.Commands;
using Dr_Purple.Application.Services.PaymentServices.Queries;
using Dr_Purple.Application.Utility.Paging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dr_Purple.Api.Controllers.Payments;
[AllowAnonymous]

public class OrderPaymentController : ApiController
{
    [HttpPost]
    [Route("Sale/Approve")]
    public async Task<IActionResult> ApproveForSaleOrderPaymentCommand([FromBody] ApproveForSaleOrderPaymentCommand command)
    => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("Sale/Create")]
    public async Task<IActionResult> CreateForSaleOrderPaymentCommand([FromBody] CreateForSaleOrderPaymentCommand command)
    => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("Sale/Materials/Create")]
    public async Task<IActionResult> CreateForSaleOrderItemCommand([FromBody] CreateForSaleOrderItemCommand command)
    => Ok(await Mediator!.Send(command));

    [HttpPut]
    [Route("Sale/Materials/Update")]
    public async Task<IActionResult> UpdateForSaleOrderItemCommand([FromBody] UpdateForSaleOrderItemCommand command)
=> Ok(await Mediator!.Send(command));

    [HttpDelete]
    [Route("Sale/Materials/Delete")]
    public async Task<IActionResult> DeleteForSaleOrderItemCommand([FromQuery] DeleteForSaleOrderItemCommand command)
    => Ok(await Mediator!.Send(command));


    [HttpGet]
    [Route("Sale/All")]
    public async Task<IActionResult> GetAllOrderPaymentQuery([FromQuery] QueryOptions options)
    => Ok(await Mediator!.Send(new GetAllSaleOrderPaymentQuery(options)));

    [HttpGet]
    [Route("Sale/Get")]
    public async Task<IActionResult> GetFirstSaleOrderPaymentQuery([FromQuery] Guid id)
    => Ok(await Mediator!.Send(new GetFirstSaleOrderPaymentQuery(id)));


    [HttpPost]
    [Route("NotSale/Approve")]
    public async Task<IActionResult> ApproveNotSaleOrderPaymentCommand([FromBody] ApproveNotForSaleOrderPaymentCommand command)
    => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("NotSale/Create")]
    public async Task<IActionResult> CreateNotSaleOrderPaymentCommand([FromBody] CreateNotForSaleOrderPaymentCommand command)
    => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("NotSale/Materials/Create")]
    public async Task<IActionResult> CreateNotForSaleOrderItemCommand([FromBody] CreateNotForSaleOrderItemCommand command)
    => Ok(await Mediator!.Send(command));

    [HttpPut]
    [Route("NotSale/Materials/Update")]
    public async Task<IActionResult> UpdateNotForSaleOrderItemCommand([FromBody] UpdateNotForSaleOrderItemCommand command)
    => Ok(await Mediator!.Send(command));

    [HttpDelete]
    [Route("NotSale/Materials/Delete")]
    public async Task<IActionResult> DeleteNotForSaleOrderItemCommand([FromQuery] DeleteNotForSaleOrderItemCommand command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("NotSale/All")]
    public async Task<IActionResult> GetAllNotSaleOrderPaymentQuery([FromQuery] QueryOptions options)
    => Ok(await Mediator!.Send(new GetAllNotSaleOrderPaymentQuery(options)));

    [HttpGet]
    [Route("NotSale/Get")]
    public async Task<IActionResult> GetFirstOrderPaymentQuery([FromQuery] Guid id)
    => Ok(await Mediator!.Send(new GetFirstNotSaleOrderPaymentQuery(id)));

}