using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.PaymentServices.Queries;

public record GetByPaymentQuery(string UserName, string Password)
    : IRequest<IDataResult<PaymentResponse>>;