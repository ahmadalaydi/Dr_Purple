using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.ContractServices.Commands.Handlers;

public class UpdateContractServiceCommandHandler : IRequestHandler<UpdateContractServiceCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public UpdateContractServiceCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(UpdateContractServiceCommand command, CancellationToken cancellationToken)
    {
        var contractService = await UnitOfWork.ContractServiceRepository.GetFirstAsync(_ => _.Id == command.Id);
        if (contractService is null)
            return new ErrorResult(Messages.ContractServiceNotFound, Messages.ContractServiceNotFoundId);

        if (await UnitOfWork.ServiceRepository.ExistsAsync(_ => _.Id == command.ServiceId) is false)
            return new ErrorResult(Messages.ServiceNotFound, Messages.ServiceNotFoundId);

        if (await UnitOfWork.ContractRepository.ExistsAsync(_ => _.Id == command.ContractId) is false)
            return new ErrorResult(Messages.ContractNotFound, Messages.ContractNotFoundId);

        contractService.Update(command.ContractId, command.ServiceId, command.Percent, command.Day, TimeSpan.Parse(command.StartTime), TimeSpan.Parse(command.EndTime));
        await UnitOfWork.ContractServiceRepository.UpdateAsync(contractService);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessDataResult<ContractService>(contractService, Messages.ContractServiceUpdated, Messages.ContractServiceUpdatedId);
    }
}