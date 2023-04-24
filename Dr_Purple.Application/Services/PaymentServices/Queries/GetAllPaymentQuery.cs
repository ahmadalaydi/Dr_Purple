using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.PaymentServices.Queries;

public record GetAllPaymentQuery(string UserName, string Password)
    : IRequest<IDataResult<PaymentResponse>>;