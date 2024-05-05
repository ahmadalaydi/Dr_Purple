using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.PaymentServices.Commands;

public record DeleteNotForSaleOrderPaymentCommand(Guid Id) : IRequest<IResult>;