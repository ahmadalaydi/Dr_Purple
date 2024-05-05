using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Services;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.ServiceServices.Queries.Handlers;

public class GetFirstServiceQueryHandler : IRequestHandler<GetFirstServiceQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetFirstServiceQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(GetFirstServiceQuery request, CancellationToken cancellationToken)
    {
        var service = await UnitOfWork.ServiceRepository.GetFirstAsync(_ => _.Id == request.Id);

        return service is null
            ? new ErrorResult(Messages.ServiceNotFound, Messages.ServiceNotFoundId)
            : new SuccsessDataResult<Service>(service, Messages.ServiceExists, Messages.ServiceExistsId);
    }
}