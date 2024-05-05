using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Departments.Base;
using Dr_Purple.Domain.Entities.Departments.Interfaces;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.DepartmentServices.Commands.Handlers;

public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public CreateDepartmentCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(CreateDepartmentCommand command, CancellationToken cancellationToken)
    {
        var department = IDepartment.Create(command.Name);

        await UnitOfWork.DepartmentRepository.AddAsync(department);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessDataResult<Department>(department, Messages.DepartmentCreated, Messages.DepartmentCreatedId);
    }
}