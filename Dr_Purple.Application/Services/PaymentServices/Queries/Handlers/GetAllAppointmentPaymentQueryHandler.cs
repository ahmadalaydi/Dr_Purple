using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Paging;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Payments;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.PaymentServices.Queries.Handlers;

public class GetAllAppointmentPaymentQueryHandler : IRequestHandler<GetAllAppointmentPaymentQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetAllAppointmentPaymentQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;

    public async Task<IResult> Handle(GetAllAppointmentPaymentQuery request, CancellationToken cancellationToken)
    {
        var Payments = await Task.FromResult(UnitOfWork.AppointmentPaymentRepository.GetAll().Search(request.Options.SearchBy).Sort(request.Options.OrderBy).GetPaged(request.Options.PageNo, request.Options.PageSize));

        return Payments.PageCount > 0
            ? new SuccsessDataResult<PagedResult<AppointmentPayment>>(Payments, Messages.PaymentListRetrieved, Messages.PaymentListRetrievedId)
            : new ErrorResult(Messages.EmptyPaymentList, Messages.EmptyPaymentListId);
    }
}