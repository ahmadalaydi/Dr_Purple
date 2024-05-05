using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Payments;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.PaymentServices.Commands.Handlers;

public class CreateNotForSaleOrderPaymentCommandHandler : IRequestHandler<CreateNotForSaleOrderPaymentCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public CreateNotForSaleOrderPaymentCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;

    public async Task<IResult> Handle(CreateNotForSaleOrderPaymentCommand command, CancellationToken cancellationToken)
    {
        if (!await UnitOfWork.ServiceProviderSubDepartmentRepository.ExistsAsync(_ => _.Id.Equals(command.SubDepartmentId)))
            return new ErrorResult(Messages.SubDepartmentNotFound, Messages.SubDepartmentNotFoundId);

        var payment = NotForSaleOrderPayment.Create(command.SubDepartmentId);
        foreach (var commandMaterial in command.Materials)
        {
            var material = await UnitOfWork.NotForSaleMaterialRepository.GetFirstAsync(_ => _.Id.Equals(commandMaterial.MaterialId));
            payment.Items.Add(NotForSaleOrderItem.Create(payment.Id, commandMaterial.MaterialId, material.CostPrice, commandMaterial.Quantity));
        }

        payment.Strategy.CalculateAmount(payment);
        await UnitOfWork.NotForSaleOrderPaymentRepository.AddAsync(payment);
        await UnitOfWork.NotForSaleOrderItemRepository.AddRangeAsync(payment.Items);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessDataResult<NotForSaleOrderPayment>(payment, Messages.PaymentCreated, Messages.PaymentCreatedId);
    }
}