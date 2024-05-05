using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.PaymentServices.Commands.Handlers;

public class UpdateForSaleOrderItemCommandHandler : IRequestHandler<UpdateForSaleOrderItemCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public UpdateForSaleOrderItemCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;

    public async Task<IResult> Handle(UpdateForSaleOrderItemCommand command, CancellationToken cancellationToken)
    {
        var PaymentItem = await UnitOfWork.ForSaleOrderItemRepository.GetFirstAsync(_ => _.Id.Equals(command.ItemId));
        if (PaymentItem is null)
            return new ErrorResult(Messages.OrderItemNotFound, Messages.OrderItemNotFoundId);

        var material = await UnitOfWork.ForSaleMaterialRepository.GetFirstAsync(_ => _.Id.Equals(PaymentItem.MaterialId));

        var Payment = await UnitOfWork.ForSaleOrderPaymentRepository.GetFirstAsync(_ => _.Id.Equals(PaymentItem.PaymentId));
        Payment.Items.FirstOrDefault(_ => _.Id.Equals(command.ItemId))!.Update(material.CostPrice, command.Quantity);
        Payment.Update();

        await UnitOfWork.ForSaleOrderItemRepository.UpdateAsync(PaymentItem);
        await UnitOfWork.ForSaleOrderPaymentRepository.UpdateAsync(Payment);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessResult(Messages.PaymentDeleted, Messages.PaymentDeletedId);
    }
}