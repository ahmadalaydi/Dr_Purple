using Dr_Purple.Application.Constants.Messagess;

using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.AttendServices.Queries.Handlers;

public class GetFirstAttendQueryHandler : IRequestHandler<GetFirstAttendQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetFirstAttendQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(GetFirstAttendQuery request, CancellationToken cancellationToken)
    {
        var attend = await UnitOfWork.AttendRepository.GetFirstAsync(_ => _.Id == request.Id);

        return attend is null
            ? new ErrorResult(Messages.AttendNotFound, Messages.AttendNotFoundId)
            : new SuccsessDataResult<Attend>(attend, Messages.AttendExists, Messages.AttendExistsId);
    }
}