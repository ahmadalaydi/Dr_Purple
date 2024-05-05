using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.ContractServices.Queries.Handlers;

public class GetFirstContractQueryHandler : IRequestHandler<GetFirstContractQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetFirstContractQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(GetFirstContractQuery request, CancellationToken cancellationToken)
    {
        var contract = await UnitOfWork.ContractRepository.GetFirstAsync(_ => _.Id == request.Id);

        return contract is null
            ? new ErrorResult(Messages.ContractNotFound, Messages.ContractNotFoundId)
            : new SuccsessDataResult<Contract>(contract, Messages.ContractExists, Messages.ContractExistsId);
    }
}