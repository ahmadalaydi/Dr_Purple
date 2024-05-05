using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Payments;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.PaymentServices.Commands.Handlers;

public class CreateForSaleOrderPaymentCommandHandler : IRequestHandler<CreateForSaleOrderPaymentCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public CreateForSaleOrderPaymentCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;

    public async Task<IResult> Handle(CreateForSaleOrderPaymentCommand command, CancellationToken cancellationToken)
    {
        if (!await UnitOfWork.SaleSubDepartmentRepository.ExistsAsync(_ => _.Id.Equals(command.SubDepartmentId)))
            return new ErrorResult(Messages.SubDepartmentNotFound, Messages.SubDepartmentNotFoundId);

        var payment = ForSaleOrderPayment.Create(command.SubDepartmentId);
        foreach (var commandMaterial in command.Materials)
        {
            var material = await UnitOfWork.ForSaleMaterialRepository.GetFirstAsync(_ => _.Id.Equals(commandMaterial.MaterialId));
            if (material is null)
                return new ErrorResult(Messages.MaterialNotFound, Messages.MaterialNotFoundId);

            payment.Items.Add(ForSaleOrderItem.Create(payment.Id, commandMaterial.MaterialId, material.CostPrice, commandMaterial.Quantity));
        }

        payment.Strategy.CalculateAmount(payment);
        await UnitOfWork.ForSaleOrderPaymentRepository.AddAsync(payment);
        await UnitOfWork.ForSaleOrderItemRepository.AddRangeAsync(payment.Items);

        await UnitOfWork.SaveChangesAsync();

        return new SuccsessDataResult<ForSaleOrderPayment>(payment, Messages.PaymentCreated, Messages.PaymentCreatedId);
    }
}