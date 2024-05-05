using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Departments.Base;
using Dr_Purple.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dr_Purple.Application.Services.PaymentServices.Commands.Handlers;

public class ApproveForSaleOrderPaymentCommandHandler : IRequestHandler<ApproveForSaleOrderPaymentCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public ApproveForSaleOrderPaymentCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(ApproveForSaleOrderPaymentCommand command, CancellationToken cancellationToken)
    {
        var Payment = await Task.FromResult(UnitOfWork.ForSaleOrderPaymentRepository.GetBy(_ => _.Id.Equals(command.Id))
            .Include(_ => _.Items).AsSplitQuery().AsNoTracking()
            .Include(_ => _.SubDepartment).AsSplitQuery().AsNoTracking()
            .First());

        if (Payment is null)
            return new ErrorResult(Messages.PaymentNotFound, Messages.PaymentNotFoundId);
        
        Payment.State.Approve(Payment);
        
        await UnitOfWork.SaleSubDepartmentRepository.UpdateAsync(Payment.SubDepartment!);
        await UnitOfWork.ForSaleOrderPaymentRepository.UpdateAsync(Payment);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessResult(Messages.PaymentDeleted, Messages.PaymentDeletedId);
    }
}