using Dr_Purple.Api.Controllers.Base;
using Dr_Purple.Application.Services.AppointmentServices.Commands;
using Dr_Purple.Application.Services.AppointmentServices.Queries;
using Dr_Purple.Application.Utility.Paging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dr_Purple.Api.Controllers.Appointments;

[AllowAnonymous]
public class AppointmentController : ApiController
{
    [HttpPost]
    [Route("Book")]
    public async Task<IActionResult> BookAppointmentCommand([FromQuery] long id)
        => Ok(await Mediator!.Send(new BookAppointmentCommand(id)));

    [HttpPost]
    [Route("Done")]
    public async Task<IActionResult> DoneAppointmentCommand([FromQuery] long id)
    => Ok(await Mediator!.Send(new DoneAppointmentCommand(id)));

    [HttpDelete]
    [Route("Cancel")]
    public async Task<IActionResult> CancelAppointmentCommand([FromQuery] long id)
        => Ok(await Mediator!.Send(new CancelAppointmentCommand(id)));

    [HttpPost]
    [Route("Materials/Create")]
    public async Task<IActionResult> CreateAppointmentMaterialCommand([FromBody] CreateAppointmentMaterialCommand command)
    => Ok(await Mediator!.Send(command));

    [HttpPut]
    [Route("Materials/Update")]
    public async Task<IActionResult> UpdateAppointmentMaterialCommand([FromBody] UpdateAppointmentMaterialCommand command)
    => Ok(await Mediator!.Send(command));

    [HttpDelete]
    [Route("Materials/Delete")]
    public async Task<IActionResult> DeleteAppointmentMaterialCommand([FromQuery] DeleteAppointmentMaterialCommand command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("All")]
    public async Task<IActionResult> GetAllAppointmentQuery([FromQuery] QueryOptions options)
        => Ok(await Mediator!.Send(new GetAllAppointmentQuery(options)));

    [HttpGet]
    [Route("Get")]
    public async Task<IActionResult> GetFirstAppointmentQuery([FromQuery] long id)
        => Ok(await Mediator!.Send(new GetFirstAppointmentQuery(id)));

    [HttpGet]
    [Route("MyAppointments")]
    public async Task<IActionResult> GetByUserAppointmentQuery([FromQuery] QueryOptions options)
    => Ok(await Mediator!.Send(new GetByUserAppointmentQuery(options)));

    [HttpGet]
    [Route("Materials/All")]
    public async Task<IActionResult> GetAllAppointmentMaterialQuery([FromQuery] QueryOptions options)
    => Ok(await Mediator!.Send(new GetAllAppointmentMaterialQuery(options)));

    [HttpGet]
    [Route("Materials/Get")]
    public async Task<IActionResult> GetFirstAppointmentMaterialQuery([FromQuery] long id)
        => Ok(await Mediator!.Send(new GetFirstAppointmentMaterialQuery(id)));
}