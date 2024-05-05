using MediatR;

namespace Dr_Purple.Application.Services.ReportServices.Commands;

public record CreateSalePerMaterialCommand(DateOnly Date) : IRequest<Unit>;