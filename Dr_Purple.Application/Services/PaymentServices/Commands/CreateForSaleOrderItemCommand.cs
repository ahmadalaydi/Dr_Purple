using Dr_Purple.Application.DTO;
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.PaymentServices.Commands;

public record CreateForSaleOrderItemCommand(Guid PaymentId, Material Material) : IRequest<IResult>;