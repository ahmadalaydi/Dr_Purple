using Dr_Purple.Api.Controllers.Base;
using Dr_Purple.Application.Services.AuditHistoryServices.Queries;
using Dr_Purple.Application.Utility.Paging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dr_Purple.Api.Controllers.AuditHistorys;

[AllowAnonymous]
public class AuditHistoryController : ApiController
{
    [HttpGet]
    [Route("All")]
    public async Task<IActionResult> GetAllAuditHistoryQuery([FromQuery] QueryOptions options)
        => Ok(await Mediator!.Send(new GetAllAuditHistoryQuery(options)));

    [HttpGet]
    [Route("Get")]
    public async Task<IActionResult> GetFirstAuditHistoryQuery([FromQuery] long id)
        => Ok(await Mediator!.Send(new GetFirstAuditHistoryQuery(id)));
}