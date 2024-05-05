using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Departments.Base;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.DepartmentServices.Queries.Handlers;

public class GetFirstDepartmentQueryHandler : IRequestHandler<GetFirstDepartmentQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetFirstDepartmentQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(GetFirstDepartmentQuery request, CancellationToken cancellationToken)
    {
        var department = await UnitOfWork.DepartmentRepository.GetFirstAsync(_ => _.Id == request.Id);

        return department is null
            ? new ErrorResult(Messages.DepartmentNotFound, Messages.DepartmentNotFoundId)
            : new SuccsessDataResult<Department>(department, Messages.DepartmentExists, Messages.DepartmentExistsId);
    }
}