using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Payments;
using Dr_Purple.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dr_Purple.Application.Services.PaymentServices.Commands.Handlers;

public class CreateSalePaymentCommandHandler : IRequestHandler<CreateSalePaymentCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public CreateSalePaymentCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;

    public async Task<IResult> Handle(CreateSalePaymentCommand command, CancellationToken cancellationToken)
    {
        var subdepartment = await Task.FromResult(UnitOfWork.SaleSubDepartmentRepository
            .GetBy(_ => _.Id.Equals(command.SubDepartmentId))
            .Include(_=>_.Materials).AsSplitQuery().AsNoTracking()
            .First());
        if (subdepartment is null)
            return new ErrorResult(Messages.SubDepartmentNotFound, Messages.SubDepartmentNotFoundId);

        var payment = SalePayment.Create(command.SubDepartmentId);
        foreach (var commandMaterial in command.Materials)
        {
            var materials = subdepartment.Materials.FirstOrDefault(_ => _.MaterialId.Equals(commandMaterial.MaterialId));
            if (materials is null)
                return new ErrorResult(Messages.NotAvailableQuantity, Messages.NotAvailableQuantityId);

            if (materials!.Quantity < commandMaterial.Quantity)
                return new ErrorResult(Messages.NotAvailableQuantity, Messages.NotAvailableQuantityId);

            var material = await UnitOfWork.ForSaleMaterialRepository.GetFirstAsync(_ => _.Id.Equals(commandMaterial.MaterialId));
            payment.Items.Add(SalePaymentItem.Create(payment.Id, commandMaterial.MaterialId, material.SalePrice, commandMaterial.Quantity));
        }

        payment.Update();
        await UnitOfWork.SalePaymentRepository.AddAsync(payment);
        await UnitOfWork.SalePaymentItemRepository.AddRangeAsync(payment.Items);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessResult(Messages.PaymentCreated, Messages.PaymentCreatedId);

    }
}