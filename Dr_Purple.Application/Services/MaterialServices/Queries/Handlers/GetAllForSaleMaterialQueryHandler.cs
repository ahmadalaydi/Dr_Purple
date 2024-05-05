using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Paging;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Materials;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.MaterialServices.Queries.Handlers;

public class GetAllForSaleMaterialQueryHandler : IRequestHandler<GetAllForSaleMaterialQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetAllForSaleMaterialQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;

    public async Task<IResult> Handle(GetAllForSaleMaterialQuery request, CancellationToken cancellationToken)
    {
        var Materials = await Task.FromResult(UnitOfWork.ForSaleMaterialRepository.GetAll().Sort(request.Options.OrderBy).Search(request.Options.SearchBy).GetPaged(request.Options.PageNo, request.Options.PageSize));

        return Materials.PageCount > 0
            ? new SuccsessDataResult<PagedResult<ForSaleMaterial>>(Materials, Messages.MaterialListRetrieved, Messages.MaterialListRetrievedId)
            : new ErrorResult(Messages.EmptyMaterialList, Messages.EmptyMaterialListId);
    }
}