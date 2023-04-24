using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.ContractServices.Queries;

public record GetByContractQuery(string UserName, string Password)
    : IRequest<IDataResult<ContractResponse>>;