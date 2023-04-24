using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.AppointmentServices.Queries;

public record GetAllAppointmentQuery(string UserName, string Password)
    : IRequest<IDataResult<AppointmentResponse>>;