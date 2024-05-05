using Dr_Purple.Application.Constants.Messagess;

using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Appointments;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.AppointmentServices.Queries.Handlers;

public class GetFirstAppointmentMaterialQueryHandler : IRequestHandler<GetFirstAppointmentMaterialQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetFirstAppointmentMaterialQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(GetFirstAppointmentMaterialQuery request, CancellationToken cancellationToken)
    {
        var appointmentMaterial = await UnitOfWork.AppointmentMaterialRepository.GetFirstAsync(_ => _.Id == request.Id);

        return appointmentMaterial is null
            ? new ErrorResult(Messages.AppointmentMaterialNotFound, Messages.AppointmentMaterialNotFoundId)
            : new SuccsessDataResult<AppointmentMaterial>(appointmentMaterial, Messages.AppointmentMaterialExists, Messages.AppointmentMaterialExistsId);
    }
}