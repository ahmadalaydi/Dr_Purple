using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Materials;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.MaterialServices.Commands.Handlers;

public class CreateForSaleMaterialCommandHandler : IRequestHandler<CreateForSaleMaterialCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public CreateForSaleMaterialCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(CreateForSaleMaterialCommand command, CancellationToken cancellationToken)
    {
        var material = ForSaleMaterial.Create(command.Name, command.Unit, command.CostPrice, command.SalePrice);
        await UnitOfWork.ForSaleMaterialRepository.AddAsync(material);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessDataResult<ForSaleMaterial>(material, Messages.MaterialCreated, Messages.MaterialCreatedId);
    }
}