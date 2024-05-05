using Dr_Purple.Application.Constants.Messagess;

using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Interfaces;

using MediatR;

namespace Dr_Purple.Application.Services.AdditionServices.Commands.Handlers;

public class CreateAdditionCommandHandler : IRequestHandler<CreateAdditionCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public CreateAdditionCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;

    public async Task<IResult> Handle(CreateAdditionCommand command, CancellationToken cancellationToken)
    {
        var Contract = await UnitOfWork.ContractRepository.ExistsAsync(_ => _.Id == command.ContractId);
        if (Contract is false)
            return new ErrorResult(Messages.ContractNotFoundId, Messages.ContractNotFoundId);

        var addition = Addition.Create(command.Name, command.ContractId);
        await UnitOfWork.AdditionRepository.AddAsync(addition);
        await UnitOfWork.SaveChangesAsync();


        return new SuccsessDataResult<Addition>(addition, Messages.AdditionCreated, Messages.AdditionCreatedId);
    }
}