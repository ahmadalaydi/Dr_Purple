using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.ContractServices.Queries.Handlers;

public class GetFirstJobTitleQueryHandler : IRequestHandler<GetFirstJobTitleQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetFirstJobTitleQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(GetFirstJobTitleQuery request, CancellationToken cancellationToken)
    {
        var jobTitle = await UnitOfWork.JobTitleRepository.GetFirstAsync(_ => _.Id == request.Id);

        return jobTitle is null
            ? new ErrorResult(Messages.JobTitleNotFound, Messages.JobTitleNotFoundId)
            : new SuccsessDataResult<JobTitle>(jobTitle, Messages.JobTitleExists, Messages.JobTitleExistsId);
    }
}