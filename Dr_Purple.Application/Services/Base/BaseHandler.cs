using Dr_Purple.Domain.Interfaces;
using MapsterMapper;

namespace Dr_Purple.Application.Services.Base;
public class BaseHandler
{
    protected internal IUnitOfWork? UnitOfWork { get; private set; }
    protected internal IMapper? Mapper { get; private set; }
    public BaseHandler(IUnitOfWork? unitOfWork, IMapper? mapper)
    {
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }
}