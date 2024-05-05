using Dr_Purple.Application.Behaviors.Aspect.Transaction;
using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Payments;
using Dr_Purple.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dr_Purple.Application.Services.PaymentServices.Commands.Handlers;

public class CreateSalePaymentItemCommandHandler : IRequestHandler<CreateSalePaymentItemCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public CreateSalePaymentItemCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;

    [TransactionScopeAspect]
    public async Task<IResult> Handle(CreateSalePaymentItemCommand command, CancellationToken cancellationToken)
    {
        var salePayment = await Task.FromResult(UnitOfWork.SalePaymentRepository
                               .GetBy(_ => _.Id.Equals(command.PaymentId))
                               .Include(_ => _.Items).AsSplitQuery().AsNoTracking()
                               .Include(_ => _.SubDepartment!.Materials).AsSplitQuery().AsNoTracking()
                               .First());

        if (salePayment is null)
            return new ErrorResult(Messages.PaymentNotFound, Messages.PaymentNotFoundId);

        if (salePayment.SubDepartment!.Materials.FirstOrDefault(_ => _.MaterialId.Equals(command.Material.MaterialId)) is null)
            return new ErrorResult(Messages.MaterialNotFound, Messages.MaterialNotFoundId);

        if (salePayment.Items.FirstOrDefault(_ => _.MaterialId.Equals(command.Material.MaterialId)) is not null)
            return new ErrorResult(Messages.MaterialExists, Messages.MaterialExistsId);

        var material = await UnitOfWork.ForSaleMaterialRepository.GetFirstAsync(_ => _.Id.Equals(command.Material.MaterialId));

        var Item = SalePaymentItem.Create(salePayment.Id, material.Id, material.SalePrice, command.Material.Quantity);
        salePayment.Items.Add(Item);
        salePayment.State.Update(salePayment);

        await UnitOfWork.SalePaymentRepository.UpdateAsync(salePayment);
        await UnitOfWork.SalePaymentItemRepository.AddAsync(Item);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessDataResult<SalePayment>(salePayment, Messages.PaymentMaterialCreated, Messages.PaymentMaterialCreatedId);
    }
}