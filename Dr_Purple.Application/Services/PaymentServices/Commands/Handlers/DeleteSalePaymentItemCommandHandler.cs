using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.PaymentServices.Commands.Handlers;

public class DeleteSalePaymentItemCommandHandler : IRequestHandler<DeleteSalePaymentItemCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public DeleteSalePaymentItemCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(DeleteSalePaymentItemCommand command, CancellationToken cancellationToken)
    {
        var salePaymentItem = await UnitOfWork.SalePaymentItemRepository.GetFirstAsync(_ => _.Id.Equals(command.ItemId));
        if (salePaymentItem is null)
            return new ErrorResult(Messages.OrderItemNotFound, Messages.OrderItemNotFoundId);

        var Payment = await UnitOfWork.SalePaymentRepository.GetFirstAsync(_ => _.Id.Equals(salePaymentItem.PaymentId));
        Payment.Items.Remove(salePaymentItem);
        Payment.Update();

        await UnitOfWork.SalePaymentItemRepository.DeleteAsync(salePaymentItem);
        await UnitOfWork.SalePaymentRepository.UpdateAsync(Payment);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessResult(Messages.PaymentDeleted, Messages.PaymentDeletedId);
    }
}