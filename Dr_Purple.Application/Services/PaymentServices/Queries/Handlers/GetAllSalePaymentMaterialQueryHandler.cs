using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Paging;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Payments;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.PaymentServices.Queries.Handlers;

public class GetAllSalePaymentMaterialQueryHandler : IRequestHandler<GetAllSalePaymentMaterialQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetAllSalePaymentMaterialQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(GetAllSalePaymentMaterialQuery request, CancellationToken cancellationToken)
    {
        var PaymentMaterials = await Task.FromResult(UnitOfWork.SalePaymentItemRepository.GetAll().Sort(request.Options.OrderBy).Search(request.Options.SearchBy).GetPaged(request.Options.PageNo, request.Options.PageSize));

        return PaymentMaterials.PageCount > 0
            ? new SuccsessDataResult<PagedResult<SalePaymentItem>>(PaymentMaterials, Messages.PaymentMaterialListRetrieved, Messages.PaymentMaterialListRetrievedId)
            : new ErrorResult(Messages.EmptyPaymentMaterialList, Messages.EmptyPaymentMaterialListId);
    }
}