using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.SubDepartmentServices.Queries;

public record GetFirstServiceProviderSubDepartmentQuery(long Id) : IRequest<IResult>;