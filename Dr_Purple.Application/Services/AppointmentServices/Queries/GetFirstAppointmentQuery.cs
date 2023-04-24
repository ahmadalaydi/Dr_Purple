using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.AppointmentServices.Queries;

public record GetFirstAppointmentQuery(string UserName, string Password)
    : IRequest<IDataResult<AppointmentResponse>>;