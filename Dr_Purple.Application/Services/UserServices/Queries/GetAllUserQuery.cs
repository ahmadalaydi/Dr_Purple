using Dr_Purple.Application.Utility.Paging;
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.UserServices.Queries;

public record GetAllUserQuery(QueryOptions Options) : IRequest<IResult>;