using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.AppointmentServices.Queries;

public record GetByAppointmentQuery(string UserName, string Password)
    : IRequest<IDataResult<AppointmentResponse>>;