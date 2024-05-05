using Dr_Purple.Application.Constants.Messagess;

using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.AdditionServices.Commands.Handlers;

public class UpdateAdditionCommandHandler : IRequestHandler<UpdateAdditionCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public UpdateAdditionCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;

    public async Task<IResult> Handle(UpdateAdditionCommand command, CancellationToken cancellationToken)
    {
        var addition = await UnitOfWork.AdditionRepository.GetFirstAsync(_ => _.Id == command.Id);
        if (addition is null)
            return new ErrorResult(Messages.AdditionNotFound, Messages.AdditionNotFoundId);

        if (await UnitOfWork.ContractRepository.ExistsAsync(_ => _.Id == command.ContractId) is false)
            return new ErrorResult(Messages.ContractNotFound, Messages.ContractNotFoundId);

        addition!.Update(command.Name, command.ContractId);
        await UnitOfWork.AdditionRepository.UpdateAsync(addition);
        await UnitOfWork.SaveChangesAsync();
        return new SuccsessDataResult<Addition>(addition, Messages.AdditionUpdated, Messages.AdditionUpdatedId);
    }
}