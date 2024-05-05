using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.ContractServices.Commands.Handlers;

public class UpdateContractCommandHandler : IRequestHandler<UpdateContractCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public UpdateContractCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(UpdateContractCommand command, CancellationToken cancellationToken)
    {
        var contract = await UnitOfWork.ContractRepository.GetFirstAsync(_ => _.Id == command.Id);
        if (contract is null)
            return new ErrorResult(Messages.ContractNotFound, Messages.ContractNotFoundId);

        if (await UnitOfWork.UserRepository.ExistsAsync(_ => _.Id == command.UserId) is false)
            return new ErrorResult(Messages.UserNotFound, Messages.UserNotFoundId);

        if (await UnitOfWork.DepartmentRepository.ExistsAsync(_ => _.Id == command.DepartmentId) is false)
            return new ErrorResult(Messages.SubDepartmentNotFound, Messages.SubDepartmentNotFoundId);

        if (await UnitOfWork.JobTitleRepository.ExistsAsync(_ => _.Id == command.JobTitleId) is false)
            return new ErrorResult(Messages.JobTitleNotFound, Messages.JobTitleNotFoundId);

        contract.Update(command.UserId, command.DepartmentId,
                        command.Salary, command.JobTitleId,
                        command.StartDate, command.EndDate);

        await UnitOfWork.ContractRepository.UpdateAsync(contract);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessDataResult<Contract>(contract, Messages.ContractUpdated, Messages.ContractUpdatedId);
    }
}