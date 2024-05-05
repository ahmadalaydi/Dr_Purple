using Dr_Purple.Api.Controllers.Base;
using Dr_Purple.Application.Services.WorkServices.Commands;
using Dr_Purple.Application.Services.WorkServices.Queries;
using Dr_Purple.Application.Utility.Paging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Dr_Purple.Api.Controllers.Works;
[AllowAnonymous]

public class HolidayController : ApiController
{
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateHolidayCommand([FromBody] CreateHolidayCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpDelete]
    [Route("Delete")]
    public async Task<IActionResult> DeleteHolidayCommand([FromQuery] long id)
        => Ok(await Mediator!.Send(new DeleteHolidayCommand(id)));

    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> UpdateHolidayCommand([FromQuery] long id, [FromBody] UpdateHolidayCommand command)
        => Ok(await Mediator!.Send(command with { Id = id }));

    [HttpGet]
    [Route("All")]
    public async Task<IActionResult> GetAllHolidayQuery([FromQuery] QueryOptions options)
    => Ok(await Mediator!.Send(new GetAllHolidayQuery(options)));

    [HttpGet]
    [Route("Get")]
    public async Task<IActionResult> GetFirstHolidayQuery([FromQuery] long id)
    => Ok(await Mediator!.Send(new GetFirstHolidayQuery(id)));
}