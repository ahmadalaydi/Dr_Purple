using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.ContractServices.Commands.Handlers;

public class CreateContractServiceCommandHandler : IRequestHandler<CreateContractServiceCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public CreateContractServiceCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(CreateContractServiceCommand command, CancellationToken cancellationToken)
    {
        if (await UnitOfWork.ContractRepository.ExistsAsync(_ => _.Id == command.ContractId) is false)
            return new ErrorResult(Messages.ContractNotFound, Messages.ContractNotFoundId);

        if (await UnitOfWork.ServiceRepository.ExistsAsync(_ => _.Id == command.ServiceId) is false)
            return new ErrorResult(Messages.ServiceNotFound, Messages.ServiceNotFoundId);

        var contractService = ContractService.Create(command.ContractId, command.ServiceId, command.Percent,
            command.Day, TimeSpan.Parse(command.StartTime), TimeSpan.Parse(command.EndTime));

        await UnitOfWork.ContractServiceRepository.AddAsync(contractService);
        await UnitOfWork.SaveChangesAsync();


        return new SuccsessDataResult<ContractService>(contractService, Messages.ContractServiceCreated, Messages.ContractServiceCreatedId);
    }
}