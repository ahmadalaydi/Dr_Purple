using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.ContractServices.Commands.Handlers;

public class UpdateJobTitleCommandHandler : IRequestHandler<UpdateJobTitleCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public UpdateJobTitleCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(UpdateJobTitleCommand command, CancellationToken cancellationToken)
    {
        var jobTitle = await UnitOfWork.JobTitleRepository.GetFirstAsync(_ => _.Id == command.Id);
        if (jobTitle is null)
            return new ErrorResult(Messages.JobTitleNotFound, Messages.JobTitleNotFoundId);

        jobTitle.Update(command.Name);
        await UnitOfWork.JobTitleRepository.UpdateAsync(jobTitle);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessDataResult<JobTitle>(jobTitle, Messages.JobTitleUpdated, Messages.JobTitleUpdatedId);
    }
}