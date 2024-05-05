using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Departments;
using Dr_Purple.Domain.Entities.Departments.Base;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.SubDepartmentServices.Queries.Handlers;

public class GetFirstSaleSubDepartmentQueryHandler : IRequestHandler<GetFirstSaleSubDepartmentQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetFirstSaleSubDepartmentQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;

    public async Task<IResult> Handle(GetFirstSaleSubDepartmentQuery request, CancellationToken cancellationToken)
    {
        var subDepartment = await UnitOfWork.SaleSubDepartmentRepository.GetFirstAsync(_ => _.Id == request.Id);

        return subDepartment is null
            ? new ErrorResult(Messages.SubDepartmentNotFound, Messages.SubDepartmentNotFoundId)
            : new SuccsessDataResult<SaleSubDepartment>(subDepartment, Messages.SubDepartmentExists, Messages.SubDepartmentExistsId);
    }
}