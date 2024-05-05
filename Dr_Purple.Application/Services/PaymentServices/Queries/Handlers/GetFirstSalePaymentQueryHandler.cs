using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Payments;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.PaymentServices.Queries.Handlers;

public class GetFirstSalePaymentQueryHandler : IRequestHandler<GetFirstSalePaymentQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetFirstSalePaymentQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(GetFirstSalePaymentQuery request, CancellationToken cancellationToken)
    {
        var payment = await UnitOfWork.SalePaymentRepository.GetFirstAsync(_ => _.Id == request.Id);

        return payment is null
            ? new ErrorResult(Messages.PaymentNotFound, Messages.PaymentNotFoundId)
            : new SuccsessDataResult<SalePayment>(payment, Messages.PaymentExists, Messages.PaymentExistsId);
    }
}