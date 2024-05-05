using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.AttendServices.Queries;

public record GetFirstAttendQuery(long Id) : IRequest<IResult>;