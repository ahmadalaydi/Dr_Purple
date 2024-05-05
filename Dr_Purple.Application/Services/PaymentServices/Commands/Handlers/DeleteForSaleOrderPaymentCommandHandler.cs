using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.PaymentServices.Commands.Handlers;

public class DeleteForSaleOrderPaymentCommandHandler : IRequestHandler<DeleteForSaleOrderPaymentCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public DeleteForSaleOrderPaymentCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(DeleteForSaleOrderPaymentCommand command, CancellationToken cancellationToken)
    {
        var Payment = await UnitOfWork.ForSaleOrderPaymentRepository.GetFirstAsync(_ => _.Id.Equals(command.Id));
        if (Payment is null)
            return new ErrorResult(Messages.PaymentNotFound, Messages.PaymentNotFoundId);

        Payment.State.Delete(Payment);
        await UnitOfWork.ForSaleOrderPaymentRepository.DeleteAsync(Payment);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessResult(Messages.PaymentDeleted, Messages.PaymentDeletedId);
    }
}