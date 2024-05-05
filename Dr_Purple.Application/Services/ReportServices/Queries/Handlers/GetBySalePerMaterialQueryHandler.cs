using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Reports;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.ReportServices.Queries.Handlers;

public class GetBySalePerMaterialQueryHandler : IRequestHandler<GetBySalePerMaterialQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetBySalePerMaterialQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(GetBySalePerMaterialQuery request, CancellationToken cancellationToken)
    {
        var sellPerMaterial = await Task.FromResult(UnitOfWork.SalePerMaterialRepository!
                                        .GetBy(_ => _.Date >= request.From && _.Date <= request.To));

        return !sellPerMaterial.Any()
            ? new ErrorResult(Messages.EmptySellPerMaterialList, Messages.EmptySellPerMaterialListId)
            : new SuccsessDataResult<IEnumerable<SalePerMaterial>>(sellPerMaterial, Messages.SellPerMaterialListRetrieved, Messages.SellPerMaterialListRetrievedId);
    }
}