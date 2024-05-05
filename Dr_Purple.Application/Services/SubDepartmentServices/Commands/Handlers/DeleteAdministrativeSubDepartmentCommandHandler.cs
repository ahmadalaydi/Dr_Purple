using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.SubDepartmentServices.Commands.Handlers;

public class DeleteAdministrativeSubDepartmentCommandHandler : IRequestHandler<DeleteAdministrativeSubDepartmentCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public DeleteAdministrativeSubDepartmentCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(DeleteAdministrativeSubDepartmentCommand command, CancellationToken cancellationToken)
    {
        var SubDepartment = await UnitOfWork.AdministrativeSubDepartmentRepository.GetFirstAsync(_ => _.Id == command.Id);
        if (SubDepartment is null)
            return new ErrorResult(Messages.SubDepartmentNotFound, Messages.SubDepartmentNotFoundId);

        await UnitOfWork.AdministrativeSubDepartmentRepository.DeleteAsync(SubDepartment);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessResult(Messages.SubDepartmentDeleted, Messages.SubDepartmentDeletedId);
    }
}