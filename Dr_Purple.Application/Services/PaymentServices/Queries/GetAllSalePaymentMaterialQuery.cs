using Dr_Purple.Application.Utility.Paging;
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.PaymentServices.Queries;

public record GetAllSalePaymentMaterialQuery(QueryOptions Options) : IRequest<IResult>;