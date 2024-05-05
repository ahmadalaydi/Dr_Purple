using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.ContractServices.Commands.Handlers;

public class DeleteContractServiceCommandHandler : IRequestHandler<DeleteContractServiceCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public DeleteContractServiceCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(DeleteContractServiceCommand command, CancellationToken cancellationToken)
    {
        var ContractService = await UnitOfWork.ContractServiceRepository.GetFirstAsync(_ => _.Id == command.Id);
        if (ContractService is null)
            return new ErrorResult(Messages.ContractServiceNotFound, Messages.ContractServiceNotFoundId);

        await UnitOfWork.ContractServiceRepository.DeleteAsync(ContractService);
        await UnitOfWork.SaveChangesAsync();



        return new SuccsessResult(Messages.ContractServiceDeleted, Messages.ContractServiceDeletedId);
    }
}