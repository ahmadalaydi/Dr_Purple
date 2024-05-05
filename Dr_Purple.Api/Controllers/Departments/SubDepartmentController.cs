using Dr_Purple.Api.Controllers.Base;
using Dr_Purple.Application.Services.SubDepartmentServices.Commands;
using Dr_Purple.Application.Services.SubDepartmentServices.Queries;
using Dr_Purple.Application.Utility.Paging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dr_Purple.Api.Controllers.Departments;
[AllowAnonymous]

public class SubDepartmentController : ApiController
{
    [HttpPost]
    [Route("Sale/Create")]
    public async Task<IActionResult> CreateSaleSubDepartmentCommand([FromBody] CreateSaleSubDepartmentCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpDelete]
    [Route("Sale/Delete")]
    public async Task<IActionResult> DeleteSaleSubDepartmentCommand([FromQuery] long id)
        => Ok(await Mediator!.Send(new DeleteSaleSubDepartmentCommand(id)));

    [HttpPut]
    [Route("Sale/Update")]
    public async Task<IActionResult> UpdateSaleSubDepartmentCommand([FromQuery] long id, [FromBody] UpdateSaleSubDepartmentCommand command)
        => Ok(await Mediator!.Send(command with { Id = id }));

    [HttpGet]
    [Route("Sale/All")]
    public async Task<IActionResult> GetAllSaleSubDepartmentQuery([FromQuery] QueryOptions options)
    => Ok(await Mediator!.Send(new GetAllSaleSubDepartmentQuery(options)));

    [HttpGet]
    [Route("Sale/Get")]
    public async Task<IActionResult> GetFirstSaleSubDepartmentQuery([FromQuery] long id)
    => Ok(await Mediator!.Send(new GetFirstSaleSubDepartmentQuery(id)));



    [HttpPost]
    [Route("Administrative/Create")]
    public async Task<IActionResult> CreateAdministrativeSubDepartmentCommand([FromBody] CreateAdministrativeSubDepartmentCommand command)
    => Ok(await Mediator!.Send(command));

    [HttpDelete]
    [Route("Administrative/Delete")]
    public async Task<IActionResult> DeleteAdministrativeSubDepartmentCommand([FromQuery] long id)
        => Ok(await Mediator!.Send(new DeleteAdministrativeSubDepartmentCommand(id)));

    [HttpPut]
    [Route("Administrative/Update")]
    public async Task<IActionResult> UpdateAdministrativeSubDepartmentCommand([FromQuery] long id, [FromBody] UpdateAdministrativeSubDepartmentCommand command)
        => Ok(await Mediator!.Send(command with { Id = id }));

    [HttpGet]
    [Route("Administrative/All")]
    public async Task<IActionResult> GetAllAdministrativeSubDepartmentQuery([FromQuery] QueryOptions options)
    => Ok(await Mediator!.Send(new GetAllAdministrativeSubDepartmentQuery(options)));

    [HttpGet]
    [Route("Administrative/Get")]
    public async Task<IActionResult> GetFirstAdministrativeSubDepartmentQuery([FromQuery] long id)
    => Ok(await Mediator!.Send(new GetFirstAdministrativeSubDepartmentQuery(id)));




    [HttpPost]
    [Route("ServiceProvider/Create")]
    public async Task<IActionResult> CreateServiceProviderSubDepartmentCommand([FromBody] CreateServiceProviderSubDepartmentCommand command)
    => Ok(await Mediator!.Send(command));

    [HttpDelete]
    [Route("ServiceProvider/Delete")]
    public async Task<IActionResult> DeleteServiceProviderSubDepartmentCommand([FromQuery] long id)
        => Ok(await Mediator!.Send(new DeleteServiceProviderSubDepartmentCommand(id)));

    [HttpPut]
    [Route("ServiceProvider/Update")]
    public async Task<IActionResult> UpdateServiceProviderSubDepartmentCommand([FromQuery] long id, [FromBody] UpdateServiceProviderSubDepartmentCommand command)
        => Ok(await Mediator!.Send(command with { Id = id }));

    [HttpGet]
    [Route("ServiceProvider/All")]
    public async Task<IActionResult> GetAllServiceProviderSubDepartmentQuery([FromQuery] QueryOptions options)
    => Ok(await Mediator!.Send(new GetAllServiceProviderSubDepartmentQuery(options)));

    [HttpGet]
    [Route("ServiceProvider/Get")]
    public async Task<IActionResult> GetFirstServiceProviderSubDepartmentQuery([FromQuery] long id)
    => Ok(await Mediator!.Send(new GetFirstServiceProviderSubDepartmentQuery(id)));
}