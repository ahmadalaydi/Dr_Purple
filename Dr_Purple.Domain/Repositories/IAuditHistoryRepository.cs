using Dr_Purple.Domain.Entities.Auditing;
using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Repositories;
public interface IAuditHistoryRepository : IReadRepository<AuditHistory> { }