using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Files;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Blogs;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.BlogServices.Commands.Handlers;

public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, IResult>
{
    private readonly IFileHelper FileHelper;
    private readonly IUnitOfWork UnitOfWork;
    public CreateBlogCommandHandler(IUnitOfWork unitOfWork, IFileHelper fileHelper)
    {
        UnitOfWork = unitOfWork;
        FileHelper = fileHelper;
    }

    public async Task<IResult> Handle(CreateBlogCommand command, CancellationToken cancellationToken)
    {
        var blog = Blog.Create(command.Title, command.Content, false, FileHelper.Upload("Blogs\\", command.Picture!));
        await UnitOfWork.BlogRepository.AddAsync(blog);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessDataResult<Blog>(blog, Messages.BlogCreated, Messages.BlogCreatedId);
    }
}