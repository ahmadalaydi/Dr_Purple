using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dr_Purple.Application.Services.PaymentServices.Commands.Handlers;

public class ApproveNotForSaleOrderPaymentCommandHandler : IRequestHandler<ApproveNotForSaleOrderPaymentCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public ApproveNotForSaleOrderPaymentCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(ApproveNotForSaleOrderPaymentCommand command, CancellationToken cancellationToken)
    {
        var Payment = await Task.FromResult(UnitOfWork.NotForSaleOrderPaymentRepository
            .GetBy(_ => _.Id.Equals(command.Id))
            .Include(_ => _.Items).AsSplitQuery().AsNoTracking()
            .Include(_ => _.SubDepartment!.Materials).AsSplitQuery().AsNoTracking()
            .First());

        if (Payment is null)
            return new ErrorResult(Messages.PaymentNotFound, Messages.PaymentNotFoundId);

        Payment.State.Approve(Payment);

        await UnitOfWork.ServiceProviderSubDepartmentRepository.UpdateAsync(Payment.SubDepartment!);
        await UnitOfWork.NotForSaleOrderPaymentRepository.UpdateAsync(Payment);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessResult(Messages.PaymentDeleted, Messages.PaymentDeletedId);
    }
}