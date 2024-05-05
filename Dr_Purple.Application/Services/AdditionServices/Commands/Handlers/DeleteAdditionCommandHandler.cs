using Dr_Purple.Application.Constants.Messagess;

using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.AdditionServices.Commands.Handlers;

public class DeleteAdditionCommandHandler : IRequestHandler<DeleteAdditionCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public DeleteAdditionCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;

    public async Task<IResult> Handle(DeleteAdditionCommand command, CancellationToken cancellationToken)
    {
        var addition = await UnitOfWork.AdditionRepository.GetFirstAsync(_ => _.Id == command.Id);

        if (addition is null)
            return new ErrorResult(Messages.AdditionNotFound, Messages.AdditionNotFoundId);

        await UnitOfWork.AdditionRepository.DeleteAsync(addition);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessResult(Messages.AdditionDeleted, Messages.AdditionDeletedId);
    }
}