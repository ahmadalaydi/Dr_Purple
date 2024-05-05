using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.ContractServices.Queries.Handlers;

public class GetFirstContractServiceQueryHandler : IRequestHandler<GetFirstContractServiceQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetFirstContractServiceQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(GetFirstContractServiceQuery request, CancellationToken cancellationToken)
    {
        var contractService = await UnitOfWork.ContractServiceRepository.GetFirstAsync(_ => _.Id == request.Id);

        return contractService is null
            ? new ErrorResult(Messages.ContractServiceNotFound, Messages.ContractServiceNotFoundId)
            : new SuccsessDataResult<ContractService>(contractService, Messages.ContractServiceExists, Messages.ContractServiceExistsId);
    }
}