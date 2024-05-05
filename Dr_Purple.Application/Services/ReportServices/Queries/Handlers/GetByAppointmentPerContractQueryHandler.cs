using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Reports;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.ReportServices.Queries.Handlers;

public class GetByAppointmentPerContractQueryHandler : IRequestHandler<GetByAppointmentPerContractQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetByAppointmentPerContractQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(GetByAppointmentPerContractQuery request, CancellationToken cancellationToken)
    {
        var appointmentPerContract = await Task.FromResult(UnitOfWork.AppointmentPerContractRepository!
                                        .GetBy(_ => _.Date >= request.From && _.Date <= request.To));

        return !appointmentPerContract.Any()
            ? new ErrorResult(Messages.EmptyAppointmentPerContractList, Messages.EmptyAppointmentPerContractListId)
            : new SuccsessDataResult<IEnumerable<AppointmentPerContract>>(appointmentPerContract,
                                Messages.AppointmentPerContractListRetrieved,
                                Messages.AppointmentPerContractListRetrievedId);
    }
}