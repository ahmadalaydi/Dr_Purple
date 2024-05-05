using Dr_Purple.Application.Constants.Messagess;

using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.AdditionServices.Queries.Handlers;

public class GetFirstAdditionQueryHandler : IRequestHandler<GetFirstAdditionQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetFirstAdditionQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;

    public async Task<IResult> Handle(GetFirstAdditionQuery request, CancellationToken cancellationToken)
    {
        var addition = await UnitOfWork.AdditionRepository.GetFirstAsync(_ => _.Id == request.Id);

        return addition is null
            ? new ErrorResult(Messages.AdditionNotFound, Messages.AdditionNotFoundId)
            : new SuccsessDataResult<Addition>(addition, Messages.AdditionExists, Messages.AdditionExistsId);
    }
}