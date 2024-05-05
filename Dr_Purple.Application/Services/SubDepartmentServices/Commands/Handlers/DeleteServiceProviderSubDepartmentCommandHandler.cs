using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.SubDepartmentServices.Commands.Handlers;

public class DeleteServiceProviderSubDepartmentCommandHandler : IRequestHandler<DeleteServiceProviderSubDepartmentCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public DeleteServiceProviderSubDepartmentCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(DeleteServiceProviderSubDepartmentCommand command, CancellationToken cancellationToken)
    {
        var SubDepartment = await UnitOfWork.ServiceProviderSubDepartmentRepository.GetFirstAsync(_ => _.Id == command.Id);
        if (SubDepartment is null)
            return new ErrorResult(Messages.SubDepartmentNotFound, Messages.SubDepartmentNotFoundId);

        await UnitOfWork.ServiceProviderSubDepartmentRepository.DeleteAsync(SubDepartment);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessResult(Messages.SubDepartmentDeleted, Messages.SubDepartmentDeletedId);
    }
}