using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.PaymentServices.Commands.Handlers;

public class UpdateSalePaymentItemCommandHandler : IRequestHandler<UpdateSalePaymentItemCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public UpdateSalePaymentItemCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;

    public async Task<IResult> Handle(UpdateSalePaymentItemCommand command, CancellationToken cancellationToken)
    {
        var PaymentItem = await UnitOfWork.SalePaymentItemRepository.GetFirstAsync(_ => _.Id.Equals(command.ItemId));
        if (PaymentItem is null)
            return new ErrorResult(Messages.OrderItemNotFound, Messages.OrderItemNotFoundId);

        var material = await UnitOfWork.ForSaleMaterialRepository.GetFirstAsync(_ => _.Id.Equals(PaymentItem.MaterialId));

        var Payment = await UnitOfWork.SalePaymentRepository.GetFirstAsync(_ => _.Id.Equals(PaymentItem.PaymentId));
        Payment.Items.FirstOrDefault(_ => _.Id.Equals(command.ItemId))!.Update(material.SalePrice, command.Quantity);
        Payment.Update();

        await UnitOfWork.SalePaymentItemRepository.UpdateAsync(PaymentItem);
        await UnitOfWork.SalePaymentRepository.UpdateAsync(Payment);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessResult(Messages.PaymentDeleted, Messages.PaymentDeletedId);
    }
}