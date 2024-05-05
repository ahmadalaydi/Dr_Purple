using Dr_Purple.Application.Utility.Paging;
using Dr_Purple.Application.Utility.Results;
using MediatR;


namespace Dr_Purple.Application.Services.SubDepartmentServices.Queries;

public record GetAllSaleSubDepartmentQuery(QueryOptions Options) : IRequest<IResult>;