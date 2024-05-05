using Dr_Purple.Application.Constants.Messagess;

using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Appointments;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.AppointmentServices.Queries.Handlers;

public class GetFirstAppointmentQueryHandler : IRequestHandler<GetFirstAppointmentQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetFirstAppointmentQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(GetFirstAppointmentQuery request, CancellationToken cancellationToken)
    {
        var appointment = await UnitOfWork.AppointmentRepository.GetFirstAsync(_ => _.Id == request.Id);

        return appointment is null
            ? new ErrorResult(Messages.AppointmentNotFound, Messages.AppointmentNotFoundId)
            : new SuccsessDataResult<Appointment>(appointment, Messages.AppointmentExists, Messages.AppointmentExistsId);
    }
}