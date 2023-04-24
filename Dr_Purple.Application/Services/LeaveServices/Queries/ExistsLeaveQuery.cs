using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.LeaveServices.Queries;

public record ExistsLeaveQuery(string UserName, string Password)
    : IRequest<IDataResult<LeaveResponse>>;