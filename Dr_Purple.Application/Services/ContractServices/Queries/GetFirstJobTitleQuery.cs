using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.ContractServices.Queries;

public record GetFirstJobTitleQuery(long Id) : IRequest<IResult>;