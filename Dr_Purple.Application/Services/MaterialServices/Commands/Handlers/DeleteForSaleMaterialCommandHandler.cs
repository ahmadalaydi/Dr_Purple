using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.MaterialServices.Commands.Handlers;

public class DeleteForSaleMaterialCommandHandler : IRequestHandler<DeleteForSaleMaterialCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public DeleteForSaleMaterialCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(DeleteForSaleMaterialCommand command, CancellationToken cancellationToken)
    {
        var Material = await UnitOfWork.ForSaleMaterialRepository.GetFirstAsync(_ => _.Id.Equals(command.Id));
        if (Material is null)
            return new ErrorResult(Messages.MaterialNotFound, Messages.MaterialNotFoundId);

        await UnitOfWork.ForSaleMaterialRepository.DeleteAsync(Material);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessResult(Messages.MaterialDeleted, Messages.MaterialDeletedId);
    }
}