using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.DepartmentServices.Commands.Handlers;

public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public DeleteDepartmentCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(DeleteDepartmentCommand command, CancellationToken cancellationToken)
    {
        var Department = await UnitOfWork.DepartmentRepository.GetFirstAsync(_ => _.Id == command.Id);
        if (Department is null)
            return new ErrorResult(Messages.DepartmentNotFound, Messages.DepartmentNotFoundId);

        await UnitOfWork.DepartmentRepository.DeleteAsync(Department);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessResult(Messages.DepartmentDeleted, Messages.DepartmentDeletedId);
    }
}