using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.PaymentServices.Commands.Handlers;

public class DeleteNotForSaleOrderPaymentCommandHandler : IRequestHandler<DeleteNotForSaleOrderPaymentCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public DeleteNotForSaleOrderPaymentCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(DeleteNotForSaleOrderPaymentCommand command, CancellationToken cancellationToken)
    {
        var Payment = await UnitOfWork.NotForSaleOrderPaymentRepository.GetFirstAsync(_ => _.Id.Equals(command.Id));
        if (Payment is null)
            return new ErrorResult(Messages.PaymentNotFound, Messages.PaymentNotFoundId);

        Payment.State.Delete(Payment);
        await UnitOfWork.NotForSaleOrderPaymentRepository.DeleteAsync(Payment);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessResult(Messages.PaymentDeleted, Messages.PaymentDeletedId);
    }
}