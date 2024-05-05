using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.PaymentServices.Commands.Handlers;

public class UpdateNotForSaleOrderItemCommandHandler : IRequestHandler<UpdateNotForSaleOrderItemCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public UpdateNotForSaleOrderItemCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;

    public async Task<IResult> Handle(UpdateNotForSaleOrderItemCommand command, CancellationToken cancellationToken)
    {
        var PaymentItem = await UnitOfWork.NotForSaleOrderItemRepository.GetFirstAsync(_ => _.Id.Equals(command.ItemId));
        if (PaymentItem is null)
            return new ErrorResult(Messages.OrderItemNotFound, Messages.OrderItemNotFoundId);

        var material = await UnitOfWork.NotForSaleMaterialRepository.GetFirstAsync(_ => _.Id.Equals(PaymentItem.MaterialId));

        var Payment = await UnitOfWork.NotForSaleOrderPaymentRepository.GetFirstAsync(_ => _.Id.Equals(PaymentItem.PaymentId));
        Payment.Items.FirstOrDefault(_ => _.Id.Equals(command.ItemId))!.Update(material.CostPrice, command.Quantity);
        Payment.Update();

        await UnitOfWork.NotForSaleOrderItemRepository.UpdateAsync(PaymentItem);
        await UnitOfWork.NotForSaleOrderPaymentRepository.UpdateAsync(Payment);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessResult(Messages.PaymentDeleted, Messages.PaymentDeletedId);
    }
}