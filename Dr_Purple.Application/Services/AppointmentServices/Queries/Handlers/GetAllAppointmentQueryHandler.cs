using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Paging;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Appointments;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.AppointmentServices.Queries.Handlers;

public class GetAllAppointmentQueryHandler : IRequestHandler<GetAllAppointmentQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetAllAppointmentQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(GetAllAppointmentQuery request, CancellationToken cancellationToken)
    {
        var Appointments = await Task.FromResult(UnitOfWork.AppointmentRepository.GetAll()
            .Sort(request.Options.OrderBy)
            .Search(request.Options.SearchBy)
            .GetPaged(request.Options.PageNo, request.Options.PageSize));

        return Appointments.PageCount > 0
            ? new SuccsessDataResult<PagedResult<Appointment>>(Appointments, Messages.AppointmentListRetrieved, Messages.AppointmentListRetrievedId)
            : new ErrorResult(Messages.EmptyAppointmentList, Messages.EmptyAppointmentListId);
    }
}