using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.PaymentServices.Commands.Handlers;

public class DeleteNotForSaleOrderItemCommandHandler : IRequestHandler<DeleteNotForSaleOrderItemCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public DeleteNotForSaleOrderItemCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(DeleteNotForSaleOrderItemCommand command, CancellationToken cancellationToken)
    {
        var PaymentItem = await UnitOfWork.NotForSaleOrderItemRepository.GetFirstAsync(_ => _.Id.Equals(command.ItemId));
        if (PaymentItem is null)
            return new ErrorResult(Messages.OrderItemNotFound, Messages.OrderItemNotFoundId);

        var Payment = await UnitOfWork.NotForSaleOrderPaymentRepository.GetFirstAsync(_ => _.Id.Equals(PaymentItem.PaymentId));
        Payment.Items.Remove(PaymentItem);
        Payment.Update();

        await UnitOfWork.NotForSaleOrderItemRepository.DeleteAsync(PaymentItem);
        await UnitOfWork.NotForSaleOrderPaymentRepository.UpdateAsync(Payment);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessResult(Messages.PaymentDeleted, Messages.PaymentDeletedId);
    }
}