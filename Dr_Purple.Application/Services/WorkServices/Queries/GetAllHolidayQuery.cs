using Dr_Purple.Application.Utility.Paging;
using Dr_Purple.Application.Utility.Results;
using MediatR;


namespace Dr_Purple.Application.Services.WorkServices.Queries;

public record GetAllHolidayQuery(QueryOptions Options) : IRequest<IResult>;