using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.ContractServices.Commands.Handlers;

public class DeleteJobTitleCommandHandler : IRequestHandler<DeleteJobTitleCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public DeleteJobTitleCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(DeleteJobTitleCommand command, CancellationToken cancellationToken)
    {
        var JobTitle = await UnitOfWork.JobTitleRepository.GetFirstAsync(_ => _.Id == command.Id);
        if (JobTitle is null)
            return new ErrorResult(Messages.JobTitleNotFound, Messages.JobTitleNotFoundId);

        await UnitOfWork.JobTitleRepository.DeleteAsync(JobTitle);
        await UnitOfWork.SaveChangesAsync();



        return new SuccsessResult(Messages.JobTitleDeleted, Messages.JobTitleDeletedId);
    }
}