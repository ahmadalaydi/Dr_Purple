using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Departments.Base;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.DepartmentServices.Commands.Handlers;

public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public UpdateDepartmentCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(UpdateDepartmentCommand command, CancellationToken cancellationToken)
    {
        var department = await UnitOfWork.DepartmentRepository.GetFirstAsync(_ => _.Id == command.Id);

        if (department is null)
            return new ErrorResult(Messages.DepartmentNotFound, Messages.DepartmentNotFoundId);


        department.Update(command.Name);

        await UnitOfWork.DepartmentRepository.UpdateAsync(department);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessDataResult<Department>(department, Messages.DepartmentUpdated, Messages.DepartmentUpdatedId);
    }
}