using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.SubDepartmentServices.Commands.Handlers;

public class DeleteSaleSubDepartmentCommandHandler : IRequestHandler<DeleteSaleSubDepartmentCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public DeleteSaleSubDepartmentCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(DeleteSaleSubDepartmentCommand command, CancellationToken cancellationToken)
    {
        var SubDepartment = await UnitOfWork.SaleSubDepartmentRepository.GetFirstAsync(_ => _.Id == command.Id);
        if (SubDepartment is null)
            return new ErrorResult(Messages.SubDepartmentNotFound, Messages.SubDepartmentNotFoundId);

        await UnitOfWork.SaleSubDepartmentRepository.DeleteAsync(SubDepartment);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessResult(Messages.SubDepartmentDeleted, Messages.SubDepartmentDeletedId);
    }
}