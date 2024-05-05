using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Paging;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Appointments;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.AppointmentServices.Queries.Handlers;

public class GetAllAppointmentMaterialQueryHandler : IRequestHandler<GetAllAppointmentMaterialQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetAllAppointmentMaterialQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(GetAllAppointmentMaterialQuery request, CancellationToken cancellationToken)
    {
        var AppointmentMaterials = await Task.FromResult(UnitOfWork.AppointmentMaterialRepository.GetAll()
            .Sort(request.Options.OrderBy)
            .Search(request.Options.SearchBy)
            .GetPaged(request.Options.PageNo, request.Options.PageSize));

        return AppointmentMaterials.PageCount > 0
            ? new SuccsessDataResult<PagedResult<AppointmentMaterial>>(AppointmentMaterials, Messages.AppointmentMaterialListRetrieved, Messages.AppointmentMaterialListRetrievedId)
            : new ErrorResult(Messages.EmptyAppointmentMaterialList, Messages.EmptyAppointmentMaterialListId);
    }
}