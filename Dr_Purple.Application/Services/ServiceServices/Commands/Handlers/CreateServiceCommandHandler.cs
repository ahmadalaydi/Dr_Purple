using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Services;
using Dr_Purple.Domain.Entities.Services.Interfaces;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.ServiceServices.Commands.Handlers;

public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public CreateServiceCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;

    public async Task<IResult> Handle(CreateServiceCommand command, CancellationToken cancellationToken)
    {
        if (await UnitOfWork.ServiceProviderSubDepartmentRepository.ExistsAsync(_ => _.Id == command.SubDepartmentId) is false)
            return new ErrorResult(Messages.SubDepartmentNotFound, Messages.SubDepartmentNotFoundId);

        var service = IService.Create(command.SubDepartmentId, command.Name, command.Price, TimeSpan.Parse(command.Duration), command.Description);

        await UnitOfWork.ServiceRepository.AddAsync(service);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessDataResult<Service>(service, Messages.ServiceCreated, Messages.ServiceCreatedId);
    }
}