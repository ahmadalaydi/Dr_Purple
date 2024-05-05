using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.ContractServices.Commands.Handlers;

public class CreateJobTitleCommandHandler : IRequestHandler<CreateJobTitleCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public CreateJobTitleCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(CreateJobTitleCommand command, CancellationToken cancellationToken)
    {
        var jobTitle = JobTitle.Create(command.Name);

        await UnitOfWork.JobTitleRepository.AddAsync(jobTitle);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessDataResult<JobTitle>(jobTitle, Messages.JobTitleCreated, Messages.JobTitleCreatedId);
    }
}