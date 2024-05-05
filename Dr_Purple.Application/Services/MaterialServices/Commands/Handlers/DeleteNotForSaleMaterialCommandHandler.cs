using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.MaterialServices.Commands.Handlers;

public class DeleteNotForSaleMaterialCommandHandler : IRequestHandler<DeleteNotForSaleMaterialCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public DeleteNotForSaleMaterialCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(DeleteNotForSaleMaterialCommand command, CancellationToken cancellationToken)
    {
        var Material = await UnitOfWork.NotForSaleMaterialRepository.GetFirstAsync(_ => _.Id.Equals(command.Id));
        if (Material is null)
            return new ErrorResult(Messages.MaterialNotFound, Messages.MaterialNotFoundId);

        await UnitOfWork.NotForSaleMaterialRepository.DeleteAsync(Material);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessResult(Messages.MaterialDeleted, Messages.MaterialDeletedId);
    }
}