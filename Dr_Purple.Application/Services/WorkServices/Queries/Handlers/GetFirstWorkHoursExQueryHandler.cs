using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Works;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.WorkServices.Queries.Handlers;

public class GetFirstWorkHoursExceptionQueryHandler : IRequestHandler<GetFirstWorkHoursExceptionQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetFirstWorkHoursExceptionQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;

    public async Task<IResult> Handle(GetFirstWorkHoursExceptionQuery request, CancellationToken cancellationToken)
    {
        var workHoursException = await UnitOfWork.WorkHoursExceptionRepository.GetFirstAsync(_ => _.Id == request.Id);

        return workHoursException is null
            ? new ErrorResult(Messages.WorkHoursExceptionNotFound, Messages.WorkHoursExceptionNotFoundId)
            : new SuccsessDataResult<WorkHoursException>(workHoursException, Messages.WorkHoursExceptionExists, Messages.WorkHoursExceptionExistsId);
    }
}