using Dr_Purple.Application.DTO;
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.PaymentServices.Commands;

public record CreateSalePaymentCommand(long SubDepartmentId, HashSet<Material> Materials) : IRequest<IResult>;