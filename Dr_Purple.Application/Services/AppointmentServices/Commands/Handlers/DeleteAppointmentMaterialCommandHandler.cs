using Dr_Purple.Application.Constants.Messagess;

using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.AppointmentServices.Commands.Handlers;

public class DeleteAppointmentMaterialCommandHandler : IRequestHandler<DeleteAppointmentMaterialCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public DeleteAppointmentMaterialCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;

    public async Task<IResult> Handle(DeleteAppointmentMaterialCommand command, CancellationToken cancellationToken)
    {
        var AppointmentMaterial = await UnitOfWork.AppointmentMaterialRepository.GetFirstAsync(_ => _.MaterialId == command.MaterialId
        && _.AppointmentId == command.AppointmentId);
        if (AppointmentMaterial is null)
            return new ErrorResult(Messages.AppointmentMaterialNotFound, Messages.AppointmentMaterialNotFoundId);

        await UnitOfWork.AppointmentMaterialRepository.DeleteAsync(AppointmentMaterial);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessResult(Messages.AppointmentMaterialDeleted, Messages.AppointmentMaterialDeletedId);
    }
}