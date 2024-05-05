using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.ContractServices.Commands.Handlers;

public class DeleteContractCommandHandler : IRequestHandler<DeleteContractCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public DeleteContractCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(DeleteContractCommand command, CancellationToken cancellationToken)
    {
        var Contract = await UnitOfWork.ContractRepository.GetFirstAsync(_ => _.Id == command.Id);
        if (Contract is null)
            return new ErrorResult(Messages.ContractNotFound, Messages.ContractNotFoundId);

        await UnitOfWork.ContractRepository.DeleteAsync(Contract);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessResult(Messages.ContractDeleted, Messages.ContractDeletedId);
    }
}