using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Materials;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.MaterialServices.Queries.Handlers;

public class GetFirstForSaleMaterialQueryHandler : IRequestHandler<GetFirstForSaleMaterialQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetFirstForSaleMaterialQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(GetFirstForSaleMaterialQuery request, CancellationToken cancellationToken)
    {
        var material = await UnitOfWork.ForSaleMaterialRepository.GetFirstAsync(_ => _.Id == request.Id);

        return material is null
            ? new ErrorResult(Messages.MaterialNotFound, Messages.MaterialNotFoundId)
            : new SuccsessDataResult<ForSaleMaterial>(material, Messages.MaterialExists, Messages.MaterialExistsId);
    }
}