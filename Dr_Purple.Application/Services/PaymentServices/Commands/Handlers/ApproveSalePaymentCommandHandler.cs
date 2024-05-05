using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dr_Purple.Application.Services.PaymentServices.Commands.Handlers;

public class ApproveSalePaymentCommandHandler : IRequestHandler<ApproveSalePaymentCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public ApproveSalePaymentCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(ApproveSalePaymentCommand command, CancellationToken cancellationToken)
    {
        var Payment = await Task.FromResult(UnitOfWork.SalePaymentRepository
            .GetBy(_ => _.Id.Equals(command.Id))
            .Include(_ => _.SubDepartment!.Materials).AsSplitQuery().AsNoTracking()
            .Include(_ => _.Items).AsSplitQuery().AsNoTracking()
            .First());

        if (Payment is null)
            return new ErrorResult(Messages.PaymentNotFound, Messages.PaymentNotFoundId);

        Payment.Approve();

        await UnitOfWork.SaleSubDepartmentRepository.UpdateAsync(Payment.SubDepartment!);
        await UnitOfWork.SalePaymentRepository.UpdateAsync(Payment);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessResult(Messages.PaymentDeleted, Messages.PaymentDeletedId);
    }
}