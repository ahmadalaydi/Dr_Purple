using Dr_Purple.Application.Behaviors.Aspect.Transaction;
using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Payments;
using Dr_Purple.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dr_Purple.Application.Services.PaymentServices.Commands.Handlers;

public class CreateForSaleOrderItemCommandHandler : IRequestHandler<CreateForSaleOrderItemCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public CreateForSaleOrderItemCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;

    [TransactionScopeAspect]
    public async Task<IResult> Handle(CreateForSaleOrderItemCommand command, CancellationToken cancellationToken)
    {
        var material = await UnitOfWork.ForSaleMaterialRepository.GetFirstAsync(_ => _.Id.Equals(command.Material.MaterialId));
        if (material is null)
            return new ErrorResult(Messages.MaterialNotFound, Messages.MaterialNotFoundId);

        var salePayment = await Task.FromResult(UnitOfWork.ForSaleOrderPaymentRepository
                               .GetBy(_ => _.Id.Equals(command.PaymentId))
                               .Include(_=>_.Items).AsSplitQuery().AsNoTracking().First());

        if (salePayment is null)
            return new ErrorResult(Messages.PaymentNotFound, Messages.PaymentNotFoundId);
        
        if (salePayment.Items.FirstOrDefault(_ => _.MaterialId.Equals(command.Material.MaterialId)) is not null)
            return new ErrorResult(Messages.MaterialExists, Messages.MaterialExistsId);

        var Item = ForSaleOrderItem.Create(salePayment.Id, material.Id, material.SalePrice, command.Material.Quantity);
        salePayment.Items.Add(Item);
        salePayment.Update();

        await UnitOfWork.ForSaleOrderPaymentRepository.UpdateAsync(salePayment);
        await UnitOfWork.ForSaleOrderItemRepository.AddAsync(Item);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessDataResult<ForSaleOrderPayment>(salePayment, Messages.PaymentMaterialCreated, Messages.PaymentMaterialCreatedId);
    }
}