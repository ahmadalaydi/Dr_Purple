using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Departments;
using Dr_Purple.Domain.Entities.Departments.Base;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.SubDepartmentServices.Commands.Handlers;

public class UpdateServiceProviderSubDepartmentCommandHandler : IRequestHandler<UpdateServiceProviderSubDepartmentCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public UpdateServiceProviderSubDepartmentCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(UpdateServiceProviderSubDepartmentCommand command, CancellationToken cancellationToken)
    {
        var subDepartment = await UnitOfWork.ServiceProviderSubDepartmentRepository.GetFirstAsync(_ => _.Id == command.Id);
        if (subDepartment is null)
            return new ErrorResult(Messages.SubDepartmentNotFound, Messages.SubDepartmentNotFoundId);

        if (await UnitOfWork.DepartmentRepository.ExistsAsync(_ => _.Id == command.DepartmentId) is false)
            return new ErrorResult(Messages.DepartmentNotFound, Messages.DepartmentNotFoundId);

        subDepartment.Update(command.Name, command.DepartmentId);

        await UnitOfWork.ServiceProviderSubDepartmentRepository.UpdateAsync(subDepartment);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessDataResult<ServiceProviderSubDepartment>(subDepartment, Messages.SubDepartmentUpdated, Messages.SubDepartmentUpdatedId);
    }
}