using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Paging;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Payments;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.PaymentServices.Queries.Handlers;

public class GetAllSalePaymentQueryHandler : IRequestHandler<GetAllSalePaymentQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetAllSalePaymentQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;

    public async Task<IResult> Handle(GetAllSalePaymentQuery request, CancellationToken cancellationToken)
    {
        var Payments = await Task.FromResult(UnitOfWork.SalePaymentRepository.GetAll().Sort(request.Options.OrderBy).Search(request.Options.SearchBy).GetPaged(request.Options.PageNo, request.Options.PageSize));

        return Payments.PageCount > 0
            ? new SuccsessDataResult<PagedResult<SalePayment>>(Payments, Messages.PaymentListRetrieved, Messages.PaymentListRetrievedId)
            : new ErrorResult(Messages.EmptyPaymentList, Messages.EmptyPaymentListId);
    }
}