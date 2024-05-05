using Dr_Purple.Application.DTO;
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.PaymentServices.Commands;

public record CreateNotForSaleOrderItemCommand(Guid PaymentId, Material Material) : IRequest<IResult>;