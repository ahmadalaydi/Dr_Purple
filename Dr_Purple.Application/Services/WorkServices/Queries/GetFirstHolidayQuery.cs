using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.WorkServices.Queries;

public record GetFirstHolidayQuery(long Id) : IRequest<IResult>;