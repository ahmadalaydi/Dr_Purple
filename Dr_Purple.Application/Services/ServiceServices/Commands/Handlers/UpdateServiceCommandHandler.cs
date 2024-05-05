using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Services;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.ServiceServices.Commands.Handlers;

public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public UpdateServiceCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(UpdateServiceCommand command, CancellationToken cancellationToken)
    {
        var service = await UnitOfWork.ServiceRepository.GetFirstAsync(_ => _.Id == command.Id);
        if (service is null)
            return new ErrorResult(Messages.ServiceNotFound, Messages.ServiceNotFoundId);

        if (await UnitOfWork.ServiceProviderSubDepartmentRepository.ExistsAsync(_ => _.Id == command.SubDepartmentId) is false)
            return new ErrorResult(Messages.SubDepartmentNotFound, Messages.SubDepartmentNotFoundId);

        service.Update(command.SubDepartmentId, command.Name, command.Price, TimeSpan.Parse(command.Duration), command.Description);
        await UnitOfWork.ServiceRepository.UpdateAsync(service);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessDataResult<Service>(service, Messages.ServiceUpdated, Messages.ServiceUpdatedId);
    }
}