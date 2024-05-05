using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.ReportServices.Queries;

public record GetByAppointmentPerContractQuery(DateOnly From, DateOnly To) : IRequest<IResult>;