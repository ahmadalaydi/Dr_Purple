using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.AttendServices.Queries;

public record GetFirstAttendQuery(string UserName, string Password)
    : IRequest<IDataResult<AttendResponse>>;