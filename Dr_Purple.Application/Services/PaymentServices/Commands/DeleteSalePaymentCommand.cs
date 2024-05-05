using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.PaymentServices.Commands;

public record DeleteSalePaymentCommand(Guid Id) : IRequest<IResult>;