using Dr_Purple.Domain.Entities.Reports;
using Dr_Purple.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dr_Purple.Application.Services.ReportServices.Commands.Handlers;

public class CreateSalePerMaterialCommandHandler : IRequestHandler<CreateSalePerMaterialCommand, Unit>
{
    private readonly IUnitOfWork UnitOfWork;
    public CreateSalePerMaterialCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<Unit> Handle(CreateSalePerMaterialCommand command, CancellationToken cancellationToken)
    {
        HashSet<SalePerMaterial> SellPerMaterials = new();

        var Payments = await Task.FromResult(
            UnitOfWork.SalePaymentRepository.GetBy(_
            => DateOnly.FromDateTime(_.Date).Equals(command.Date)).AsSplitQuery().AsTracking()
            .Include(_ => _.Items).AsSplitQuery().AsTracking());

        foreach (var Payment in Payments)
        {
            foreach (var item in Payment.Items)
            {
                var Sell = SellPerMaterials.FirstOrDefault(_ => _.MaterialId.Equals(item.MaterialId));
                //Sell?.Update(item.Quantity, item.Total);
                SellPerMaterials.Add(SalePerMaterial.Create(
                        item.MaterialId, command.Date,
                        item.Quantity, item.Total));
            }
        }
        await UnitOfWork.SalePerMaterialRepository.AddRangeAsync(SellPerMaterials!);
        await UnitOfWork.SaveChangesAsync();

        return await Task.FromResult(Unit.Value);
    }
}