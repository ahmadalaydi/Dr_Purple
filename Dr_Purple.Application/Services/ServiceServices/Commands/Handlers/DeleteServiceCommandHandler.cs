using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.ServiceServices.Commands.Handlers;

public class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public DeleteServiceCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(DeleteServiceCommand command, CancellationToken cancellationToken)
    {
        var Service = await UnitOfWork.ServiceRepository.GetFirstAsync(_ => _.Id == command.Id);
        if (Service is null)
            return new ErrorResult(Messages.ServiceNotFound, Messages.ServiceNotFoundId);

        await UnitOfWork.ServiceRepository.DeleteAsync(Service);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessResult(Messages.ServiceDeleted, Messages.ServiceDeletedId);
    }
}