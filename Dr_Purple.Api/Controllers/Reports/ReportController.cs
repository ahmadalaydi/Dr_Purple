using Dr_Purple.Api.Controllers.Base;
using Dr_Purple.Application.Services.ReportServices.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dr_Purple.Api.Controllers.Reports;
[AllowAnonymous]

public class ReportController : ApiController
{
    [HttpGet]
    [Route("AppointmentPerContract")]
    public async Task<IActionResult> GetByAppointmentPerContractQuery([FromQuery] GetByAppointmentPerContractQuery query)
    => Ok(await Mediator!.Send(query));

    [HttpGet]
    [Route("AppointmentPerService")]
    public async Task<IActionResult> GetByAppointmentPerServiceQuery([FromQuery] GetByAppointmentPerServiceQuery query)
    => Ok(await Mediator!.Send(query));

    [HttpGet]
    [Route("SellPerMaterialReport")]
    public async Task<IActionResult> GetBySellPerMaterialQuery([FromQuery] GetBySalePerMaterialQuery query)
    => Ok(await Mediator!.Send(query));
}