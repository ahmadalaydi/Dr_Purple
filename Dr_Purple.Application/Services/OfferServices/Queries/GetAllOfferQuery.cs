using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.OfferServices.Queries;

public record GetAllOfferQuery(string UserName, string Password)
    : IRequest<IDataResult<OfferResponse>>;