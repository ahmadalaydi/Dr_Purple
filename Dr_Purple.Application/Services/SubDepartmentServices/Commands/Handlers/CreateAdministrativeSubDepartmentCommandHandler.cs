using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Departments;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.SubDepartmentServices.Commands.Handlers;

public class CreateAdministrativeSubDepartmentCommandHandler : IRequestHandler<CreateAdministrativeSubDepartmentCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public CreateAdministrativeSubDepartmentCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(CreateAdministrativeSubDepartmentCommand command, CancellationToken cancellationToken)
    {
        if (await UnitOfWork.DepartmentRepository.ExistsAsync(_ => _.Id == command.DepartmentId) is false)
            return new ErrorResult(Messages.DepartmentNotFound, Messages.DepartmentNotFoundId);

        var subDepartment = AdministrativeSubDepartment.Create(command.Name, command.DepartmentId);
        await UnitOfWork.AdministrativeSubDepartmentRepository.AddAsync(subDepartment);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessDataResult<AdministrativeSubDepartment>(subDepartment, Messages.SubDepartmentCreated, Messages.SubDepartmentCreatedId);
    }
}