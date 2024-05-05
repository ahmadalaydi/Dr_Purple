using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Paging;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Payments;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.PaymentServices.Queries.Handlers;

public class GetAllNotSaleOrderPaymentQueryHandler : IRequestHandler<GetAllNotSaleOrderPaymentQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetAllNotSaleOrderPaymentQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;

    public async Task<IResult> Handle(GetAllNotSaleOrderPaymentQuery request, CancellationToken cancellationToken)
    {
        var Payments = await Task.FromResult(UnitOfWork.NotForSaleOrderPaymentRepository.GetAll().Sort(request.Options.OrderBy).Search(request.Options.SearchBy).GetPaged(request.Options.PageNo, request.Options.PageSize));

        return Payments.PageCount > 0
            ? new SuccsessDataResult<PagedResult<NotForSaleOrderPayment>>(Payments, Messages.PaymentListRetrieved, Messages.PaymentListRetrievedId)
            : new ErrorResult(Messages.EmptyPaymentList, Messages.EmptyPaymentListId);
    }
}