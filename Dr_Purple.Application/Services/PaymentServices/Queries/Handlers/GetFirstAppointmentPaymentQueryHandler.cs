using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Payments;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.PaymentServices.Queries.Handlers;

public class GetFirstAppointmentPaymentQueryHandler : IRequestHandler<GetFirstAppointmentPaymentQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetFirstAppointmentPaymentQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(GetFirstAppointmentPaymentQuery request, CancellationToken cancellationToken)
    {
        var payment = await UnitOfWork.AppointmentPaymentRepository.GetFirstAsync(_ => _.Id == request.Id);

        return payment is null
            ? new ErrorResult(Messages.PaymentNotFound, Messages.PaymentNotFoundId)
            : new SuccsessDataResult<AppointmentPayment>(payment, Messages.PaymentExists, Messages.PaymentExistsId);
    }
}