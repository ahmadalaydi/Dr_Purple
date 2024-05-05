using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.PaymentServices.Commands;

public record ApproveForSaleOrderPaymentCommand(Guid Id) : IRequest<IResult>;