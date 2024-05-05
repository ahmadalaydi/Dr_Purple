using Dr_Purple.Application.Constants.Messagess;

using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.AppointmentServices.Commands.Handlers;

public class UpdateAppointmentMaterialCommandHandler : IRequestHandler<UpdateAppointmentMaterialCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public UpdateAppointmentMaterialCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;

    public async Task<IResult> Handle(UpdateAppointmentMaterialCommand command, CancellationToken cancellationToken)
    {
        //var appointmentMaterial = await UnitOfWork.AppointmentRepository.GetFirstAsync(_ => _.Id.Equals(command.AppointmentId)
        //&& _.AppointmentMaterials.FirstOrDefault(_=>_.MaterialId.Equals(command.Material.MaterialId)));
        //if (appointmentMaterial is null)
        return new ErrorResult(Messages.AppointmentMaterialNotFound, Messages.AppointmentMaterialNotFoundId);

        //appointmentMaterial.Update(command.Material.MaterialId, command.Material.Quantity);

        //await UnitOfWork.AppointmentMaterialRepository.UpdateAsync(appointmentMaterial);
        //await UnitOfWork.SaveChangesAsync();

        //return new SuccsessDataResult<AppointmentMaterial>(appointmentMaterial, Messages.AppointmentMaterialUpdated, Messages.AppointmentMaterialUpdatedId);
    }
}