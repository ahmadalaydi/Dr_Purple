using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dr_Purple.Application.Services.PaymentServices.Commands.Handlers;

public class ApproveAppointmentPaymentCommandHandler : IRequestHandler<ApproveAppointmentPaymentCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public ApproveAppointmentPaymentCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(ApproveAppointmentPaymentCommand command, CancellationToken cancellationToken)
    {
        var Payment = await Task.FromResult(UnitOfWork.AppointmentPaymentRepository
            .GetBy(_ => _.Id.Equals(command.Id))
            .Include(_ => _.Appointment).AsSplitQuery().AsNoTracking()
            .Include(_ => _.Appointment!.AppointmentMaterials).AsSplitQuery().AsNoTracking()
            .Include(_ => _.SubDepartment).AsSplitQuery().AsNoTracking()
            .First());

        if (Payment is null)
            return new ErrorResult(Messages.PaymentNotFound, Messages.PaymentNotFoundId);

        Payment.State.Approve(Payment);

        await UnitOfWork.ServiceProviderSubDepartmentRepository.UpdateAsync(Payment.SubDepartment!);
        await UnitOfWork.AppointmentPaymentRepository.UpdateAsync(Payment);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessResult(Messages.PaymentDeleted, Messages.PaymentDeletedId);
    }
}