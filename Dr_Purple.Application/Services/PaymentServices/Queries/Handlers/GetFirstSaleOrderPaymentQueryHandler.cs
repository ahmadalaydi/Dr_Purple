using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Payments;
using Dr_Purple.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dr_Purple.Application.Services.PaymentServices.Queries.Handlers;

public class GetFirstSaleOrderPaymentQueryHandler : IRequestHandler<GetFirstSaleOrderPaymentQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetFirstSaleOrderPaymentQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(GetFirstSaleOrderPaymentQuery request, CancellationToken cancellationToken)
    {
        var payment = await Task.FromResult(UnitOfWork.ForSaleOrderPaymentRepository.GetBy(_ => _.Id == request.Id)
            .Include(_ => _.Items).AsSplitQuery().AsNoTracking());

        return payment is null
            ? new ErrorResult(Messages.PaymentNotFound, Messages.PaymentNotFoundId)
            : new SuccsessDataResult<ForSaleOrderPayment>(payment.First(), Messages.PaymentExists, Messages.PaymentExistsId);
    }
}