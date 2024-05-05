using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Departments;
using Dr_Purple.Domain.Entities.Departments.Base;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.SubDepartmentServices.Commands.Handlers;

public class CreateSaleSubDepartmentCommandHandler : IRequestHandler<CreateSaleSubDepartmentCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public CreateSaleSubDepartmentCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(CreateSaleSubDepartmentCommand command, CancellationToken cancellationToken)
    {
        if (await UnitOfWork.DepartmentRepository.ExistsAsync(_ => _.Id == command.DepartmentId) is false)
            return new ErrorResult(Messages.DepartmentNotFound, Messages.DepartmentNotFoundId);

        var subDepartment = SaleSubDepartment.Create(command.Name, command.DepartmentId);
        await UnitOfWork.SaleSubDepartmentRepository.AddAsync(subDepartment);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessDataResult<SaleSubDepartment>(subDepartment, Messages.SubDepartmentCreated, Messages.SubDepartmentCreatedId);
    }
}