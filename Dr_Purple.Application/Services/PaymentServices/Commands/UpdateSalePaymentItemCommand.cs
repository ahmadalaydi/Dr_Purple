using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.PaymentServices.Commands;

public record UpdateSalePaymentItemCommand(long ItemId, float Quantity) : IRequest<IResult>;