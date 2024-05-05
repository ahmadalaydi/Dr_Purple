using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Materials;
using Dr_Purple.Domain.Entities.Materials.Interfaces;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.MaterialServices.Commands.Handlers;

public class CreateNotForSaleMaterialCommandHandler : IRequestHandler<CreateNotForSaleMaterialCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public CreateNotForSaleMaterialCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(CreateNotForSaleMaterialCommand command, CancellationToken cancellationToken)
    {
        var material = IMaterial.Create(command.Name, command.Unit, command.CostPrice);
        await UnitOfWork.NotForSaleMaterialRepository.AddAsync(material);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessDataResult<NotForSaleMaterial>(material, Messages.MaterialCreated, Messages.MaterialCreatedId);
    }
}