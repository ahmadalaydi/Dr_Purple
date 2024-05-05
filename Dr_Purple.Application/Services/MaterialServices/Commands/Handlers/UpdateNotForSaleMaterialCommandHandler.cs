using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Materials;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.MaterialServices.Commands.Handlers;

public class UpdateNotForSaleMaterialCommandHandler : IRequestHandler<UpdateNotForSaleMaterialCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public UpdateNotForSaleMaterialCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(UpdateNotForSaleMaterialCommand command, CancellationToken cancellationToken)
    {
        var material = await UnitOfWork.NotForSaleMaterialRepository.GetFirstAsync(_ => _.Id == command.Id);
        if (material is null)
            return new ErrorResult(Messages.MaterialNotFound, Messages.MaterialNotFoundId);

        material.Update(command.Name, command.Unit, command.CostPrice);

        await UnitOfWork.NotForSaleMaterialRepository.UpdateAsync(material);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessDataResult<NotForSaleMaterial>(material, Messages.MaterialUpdated, Messages.MaterialUpdatedId);
    }
}