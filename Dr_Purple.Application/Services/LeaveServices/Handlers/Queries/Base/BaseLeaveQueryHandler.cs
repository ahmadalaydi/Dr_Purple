﻿using Dr_Purple.Application.Services.Base;
using Dr_Purple.Domain.Interfaces;
using Dr_Purple.Domain.Repositories;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Dr_Purple.Application.Services.LeaveServices.Handlers.Queries.Base;
public class BaseLeaveQueryHandler : BaseHandler
{
    protected internal ILeaveRepository? Repository;
    public BaseLeaveQueryHandler(IServiceProvider? provider)
    : base(provider!.GetService<IUnitOfWork>(), provider!.GetService<IMapper>())
    {
        Repository = UnitOfWork!.LeaveRepository;
    }
}
