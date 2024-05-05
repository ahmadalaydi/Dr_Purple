using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Files;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Blogs;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.BlogServices.Commands.Handlers;

public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    private readonly IFileHelper FileHelper;
    public UpdateBlogCommandHandler(IUnitOfWork unitOfWork, IFileHelper fileHelper)
    {
        UnitOfWork = unitOfWork;
        FileHelper = fileHelper;
    }

    public async Task<IResult> Handle(UpdateBlogCommand command, CancellationToken cancellationToken)
    {
        var blog = await UnitOfWork.BlogRepository.GetFirstAsync(_ => _.Id == command.Id);
        if (blog is null)
            return new ErrorResult(Messages.BlogNotFound, Messages.BlogNotFoundId);

        blog!.Update(command.Title, command.Content, command.IsPublished, FileHelper.Upload("Blogs\\", command.Picture!));
        await UnitOfWork.BlogRepository.UpdateAsync(blog);
        await UnitOfWork.SaveChangesAsync();
        return new SuccsessDataResult<Blog>(blog, Messages.BlogUpdated, Messages.BlogUpdatedId);
    }
}