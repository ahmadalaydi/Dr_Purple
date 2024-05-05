using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Departments;
using Dr_Purple.Domain.Entities.Departments.Base;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.SubDepartmentServices.Queries.Handlers;

public class GetFirstAdministrativeSubDepartmentQueryHandler : IRequestHandler<GetFirstAdministrativeSubDepartmentQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetFirstAdministrativeSubDepartmentQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;

    public async Task<IResult> Handle(GetFirstAdministrativeSubDepartmentQuery request, CancellationToken cancellationToken)
    {
        var subDepartment = await UnitOfWork.AdministrativeSubDepartmentRepository.GetFirstAsync(_ => _.Id == request.Id);

        return subDepartment is null
            ? new ErrorResult(Messages.SubDepartmentNotFound, Messages.SubDepartmentNotFoundId)
            : new SuccsessDataResult<AdministrativeSubDepartment>(subDepartment, Messages.SubDepartmentExists, Messages.SubDepartmentExistsId);
    }
}