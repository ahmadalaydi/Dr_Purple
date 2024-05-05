using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Appointments;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.AppointmentServices.Commands.Handlers;

public class CreateAppointmentMaterialCommandHandler : IRequestHandler<CreateAppointmentMaterialCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public CreateAppointmentMaterialCommandHandler(IUnitOfWork unitOfWork)
    => UnitOfWork = unitOfWork;

    public async Task<IResult> Handle(CreateAppointmentMaterialCommand command, CancellationToken cancellationToken)
    {
        var appointment = await UnitOfWork.AppointmentRepository.GetFirstAsync(_ => _.Id.Equals(command.AppointmentId));
        if (appointment is null)
            return new ErrorResult(Messages.AppointmentNotFound, Messages.AppointmentNotFoundId);

        var subDepartmentMaterial = await UnitOfWork.ServiceProviderSubDepartmentRepository!
            .GetFirstAsync(_ => _.Id == appointment.ServiceTime!.Service!.SubDepartmentId
            && _.Materials.FirstOrDefault(_ => _.MaterialId.Equals(command.Material.MaterialId))!.Quantity > 0);

        if (subDepartmentMaterial is null)
            return new ErrorResult(Messages.MaterialNotFound, Messages.MaterialNotFoundId);

        var appointmentMaterial = AppointmentMaterial.Create(command.AppointmentId, command.Material.MaterialId, command.Material.Quantity);
        appointment.AppointmentMaterials.Add(appointmentMaterial);
        appointment.ServiceTime!.State.Update(appointment.ServiceTime);

        await UnitOfWork.ServiceProviderSubDepartmentRepository.UpdateAsync(subDepartmentMaterial);
        await UnitOfWork.AppointmentMaterialRepository.AddAsync(appointmentMaterial);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessDataResult<AppointmentMaterial>(appointmentMaterial, Messages.AppointmentMaterialCreated, Messages.AppointmentMaterialCreatedId);
    }
}