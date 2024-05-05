using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Departments;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.SubDepartmentServices.Queries.Handlers;

public class GetFirstServiceProviderSubDepartmentQueryHandler : IRequestHandler<GetFirstServiceProviderSubDepartmentQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetFirstServiceProviderSubDepartmentQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;

    public async Task<IResult> Handle(GetFirstServiceProviderSubDepartmentQuery request, CancellationToken cancellationToken)
    {
        var subDepartment = await UnitOfWork.ServiceProviderSubDepartmentRepository.GetFirstAsync(_ => _.Id == request.Id);

        return subDepartment is null
            ? new ErrorResult(Messages.SubDepartmentNotFound, Messages.SubDepartmentNotFoundId)
            : new SuccsessDataResult<ServiceProviderSubDepartment>(subDepartment, Messages.SubDepartmentExists, Messages.SubDepartmentExistsId);
    }
}