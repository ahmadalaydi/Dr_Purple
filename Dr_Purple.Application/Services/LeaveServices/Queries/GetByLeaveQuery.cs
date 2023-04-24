using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.LeaveServices.Queries;

public record GetByLeaveQuery(string UserName, string Password)
    : IRequest<IDataResult<LeaveResponse>>;