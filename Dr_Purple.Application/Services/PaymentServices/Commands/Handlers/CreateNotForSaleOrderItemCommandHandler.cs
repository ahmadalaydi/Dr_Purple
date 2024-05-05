using Dr_Purple.Application.Behaviors.Aspect.Transaction;
using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Payments;
using Dr_Purple.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dr_Purple.Application.Services.PaymentServices.Commands.Handlers;

public class CreateNotForSaleOrderItemCommandHandler : IRequestHandler<CreateNotForSaleOrderItemCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public CreateNotForSaleOrderItemCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;

    [TransactionScopeAspect]
    public async Task<IResult> Handle(CreateNotForSaleOrderItemCommand command, CancellationToken cancellationToken)
    {
        var material = await UnitOfWork.NotForSaleMaterialRepository.GetFirstAsync(_ => _.Id.Equals(command.Material.MaterialId));
        if (material is null)
            return new ErrorResult(Messages.MaterialNotFound, Messages.MaterialNotFoundId);

        var salePayment = await Task.FromResult(UnitOfWork.NotForSaleOrderPaymentRepository
                               .GetBy(_ => _.Id.Equals(command.PaymentId))
                               .Include(_ => _.Items).AsSplitQuery().AsNoTracking().First());

        if (salePayment is null)
            return new ErrorResult(Messages.PaymentNotFound, Messages.PaymentNotFoundId);

        if (salePayment.Items.FirstOrDefault(_ => _.MaterialId.Equals(command.Material.MaterialId)) is not null)
            return new ErrorResult(Messages.MaterialExists, Messages.MaterialExistsId);

        var Item = NotForSaleOrderItem.Create(salePayment.Id, material.Id, material.CostPrice, command.Material.Quantity);
        salePayment.Items.Add(Item);
        salePayment.Update();

        await UnitOfWork.NotForSaleOrderPaymentRepository.UpdateAsync(salePayment);
        await UnitOfWork.NotForSaleOrderItemRepository.AddAsync(Item);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessDataResult<NotForSaleOrderPayment>(salePayment, Messages.PaymentMaterialCreated, Messages.PaymentMaterialCreatedId);
    }
}