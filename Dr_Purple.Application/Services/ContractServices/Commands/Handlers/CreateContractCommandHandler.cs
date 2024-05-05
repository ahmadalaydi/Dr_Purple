using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.ContractServices.Commands.Handlers;

public class CreateContractCommandHandler : IRequestHandler<CreateContractCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public CreateContractCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(CreateContractCommand command, CancellationToken cancellationToken)
    {
        if (await UnitOfWork.UserRepository.ExistsAsync(_ => _.Id == command.UserId) is false)
            return new ErrorResult(Messages.UserNotFound, Messages.UserNotFoundId);

        if (await UnitOfWork.DepartmentRepository.ExistsAsync(_ => _.Id == command.DepartmentId) is false)
            return new ErrorResult(Messages.DepartmentNotFound, Messages.DepartmentNotFoundId);

        if (await UnitOfWork.JobTitleRepository.ExistsAsync(_ => _.Id == command.JobTitleId) is false)
            return new ErrorResult(Messages.JobTitleNotFound, Messages.JobTitleNotFoundId);

        var contract = Contract.Create(command.UserId, command.DepartmentId,
            command.JobTitleId, command.Salary, command.StartDate, command.EndDate);

        await UnitOfWork.ContractRepository.AddAsync(contract);
        await UnitOfWork.SaveChangesAsync();
        return new SuccsessDataResult<Contract>(contract, Messages.ContractCreated, Messages.ContractCreatedId);
    }
}