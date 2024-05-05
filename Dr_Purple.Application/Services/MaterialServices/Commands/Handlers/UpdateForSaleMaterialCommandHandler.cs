using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Materials;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.MaterialServices.Commands.Handlers;

public class UpdateForSaleMaterialCommandHandler : IRequestHandler<UpdateForSaleMaterialCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public UpdateForSaleMaterialCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(UpdateForSaleMaterialCommand command, CancellationToken cancellationToken)
    {
        var material = await UnitOfWork.ForSaleMaterialRepository.GetFirstAsync(_ => _.Id == command.Id);
        if (material is null)
            return new ErrorResult(Messages.MaterialNotFound, Messages.MaterialNotFoundId);

        material.Update(command.Name, command.Unit, command.CostPrice, command.SalePrice);

        await UnitOfWork.ForSaleMaterialRepository.UpdateAsync(material);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessDataResult<ForSaleMaterial>(material, Messages.MaterialUpdated, Messages.MaterialUpdatedId);
    }
}