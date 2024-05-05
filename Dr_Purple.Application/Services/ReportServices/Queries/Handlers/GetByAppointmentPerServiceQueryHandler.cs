using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Reports;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.ReportServices.Queries.Handlers;

public class GetByAppointmentPerServiceQueryHandler : IRequestHandler<GetByAppointmentPerServiceQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetByAppointmentPerServiceQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(GetByAppointmentPerServiceQuery request, CancellationToken cancellationToken)
    {
        var appointmentPerService = await Task.FromResult(UnitOfWork.AppointmentPerServiceRepository!
                                        .GetBy(_ => _.Date >= request.From && _.Date <= request.To));

        return !appointmentPerService.Any()
            ? new ErrorResult(Messages.EmptyAppointmentPerServiceList, Messages.EmptyAppointmentPerServiceListId)
            : new SuccsessDataResult<IEnumerable<AppointmentPerService>>(appointmentPerService,
                                            Messages.AppointmentPerServiceListRetrieved,
                                            Messages.AppointmentPerServiceListRetrievedId);
    }
}