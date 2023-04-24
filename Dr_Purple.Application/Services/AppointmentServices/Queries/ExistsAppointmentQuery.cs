using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.AppointmentServices.Queries;

public record ExistsAppointmentQuery(string UserName, string Password)
    : IRequest<IDataResult<AppointmentResponse>>;