using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.PaymentServices.Commands.Handlers;

public class DeleteForSaleOrderItemCommandHandler : IRequestHandler<DeleteForSaleOrderItemCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public DeleteForSaleOrderItemCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(DeleteForSaleOrderItemCommand command, CancellationToken cancellationToken)
    {
        var PaymentItem = await UnitOfWork.ForSaleOrderItemRepository.GetFirstAsync(_ => _.Id.Equals(command.ItemId));
        if (PaymentItem is null)
            return new ErrorResult(Messages.OrderItemNotFound, Messages.OrderItemNotFoundId);

        var Payment = await UnitOfWork.ForSaleOrderPaymentRepository.GetFirstAsync(_ => _.Id.Equals(PaymentItem.PaymentId));
        Payment.Items.Remove(PaymentItem);
        Payment.Update();

        await UnitOfWork.ForSaleOrderItemRepository.DeleteAsync(PaymentItem);
        await UnitOfWork.ForSaleOrderPaymentRepository.UpdateAsync(Payment);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessResult(Messages.PaymentDeleted, Messages.PaymentDeletedId);
    }
}