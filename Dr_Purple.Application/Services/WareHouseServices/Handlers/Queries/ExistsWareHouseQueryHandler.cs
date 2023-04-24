using Dr_Purple.Application.Constants;
using Dr_Purple.Application.Services.WareHouseServices.Handlers.Queries.Base;
using Dr_Purple.Application.Services.WareHouseServices.Queries;
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.WareHouseServices.Handlers.Queries;

public class ExistsWareHouseQueryHandler : BaseWareHouseQueryHandler,
    IRequestHandler<ExistsWareHouseQuery, IDataResult<bool>>
{
    public ExistsWareHouseQueryHandler(IServiceProvider provider) : base(provider) { }

    public async Task<IDataResult<bool>> Handle(ExistsWareHouseQuery? request, CancellationToken cancellationToken)
    {
        var Exists = await Repository!.ExistsAsync(_ => _.Name == request!.Name);

        return Exists is true ?
             new SuccsessDataResult<bool>(
                 Exists,
                 Messages.SuccessfulLogin,
                 Messages.SuccessfulLoginId)

            : new ErrorDataResult<bool>(
            Exists,
            Messages.SuccessfulLogin,
            Messages.SuccessfulLoginId);
    }
}