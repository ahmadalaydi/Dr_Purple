using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Paging;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Appointments;
using Dr_Purple.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dr_Purple.Application.Services.AppointmentServices.Queries.Handlers;

public class GetByUserAppointmentQueryHandler : IRequestHandler<GetByUserAppointmentQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    private readonly IAuthenticatedUserService AuthenticatedUserService;
    public GetByUserAppointmentQueryHandler(IUnitOfWork unitOfWork, IAuthenticatedUserService authenticatedUserService)
    {
        UnitOfWork = unitOfWork;
        AuthenticatedUserService = authenticatedUserService;
    }
    public async Task<IResult> Handle(GetByUserAppointmentQuery request, CancellationToken cancellationToken)
    {
        var Appointments = await Task.FromResult(UnitOfWork.AppointmentRepository
            .GetBy(_=>_.UserId.Equals(long.Parse(AuthenticatedUserService.UserId!)))
            .Include(_=>_.AppointmentMaterials).AsSplitQuery().AsNoTracking()
            .Include(_ => _.ServiceTime).AsSplitQuery().AsNoTracking()
            .Include(_ => _.AppointmentPayment).AsSplitQuery().AsNoTracking()
            .Sort(request.Options.OrderBy)
            .Search(request.Options.SearchBy)
            .GetPaged(request.Options.PageNo, request.Options.PageSize));

        return Appointments.PageCount > 0
            ? new SuccsessDataResult<PagedResult<Appointment>>(Appointments, Messages.AppointmentListRetrieved, Messages.AppointmentListRetrievedId)
            : new ErrorResult(Messages.EmptyAppointmentList, Messages.EmptyAppointmentListId);
    }
}