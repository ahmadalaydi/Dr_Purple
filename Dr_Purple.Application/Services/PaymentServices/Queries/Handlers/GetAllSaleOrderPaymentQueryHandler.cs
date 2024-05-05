using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Paging;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Payments;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.PaymentServices.Queries.Handlers;

public class GetAllSaleOrderPaymentQueryHandler : IRequestHandler<GetAllSaleOrderPaymentQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetAllSaleOrderPaymentQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;

    public async Task<IResult> Handle(GetAllSaleOrderPaymentQuery request, CancellationToken cancellationToken)
    {
        var Payments = await Task.FromResult(UnitOfWork.ForSaleOrderPaymentRepository.GetAll().Sort(request.Options.OrderBy).Search(request.Options.SearchBy).GetPaged(request.Options.PageNo, request.Options.PageSize));

        return Payments.PageCount > 0
            ? new SuccsessDataResult<PagedResult<ForSaleOrderPayment>>(Payments, Messages.PaymentListRetrieved, Messages.PaymentListRetrievedId)
            : new ErrorResult(Messages.EmptyPaymentList, Messages.EmptyPaymentListId);
    }
}