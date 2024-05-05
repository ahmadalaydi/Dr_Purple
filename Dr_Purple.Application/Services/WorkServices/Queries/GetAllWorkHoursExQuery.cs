using Dr_Purple.Application.Utility.Paging;
using Dr_Purple.Application.Utility.Results;
using MediatR;


namespace Dr_Purple.Application.Services.WorkServices.Queries;

public record GetAllWorkHoursExceptionQuery(QueryOptions Options) : IRequest<IResult>;