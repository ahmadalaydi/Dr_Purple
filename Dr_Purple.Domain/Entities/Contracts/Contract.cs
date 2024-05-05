using Dr_Purple.Domain.Entities.Base;
using Dr_Purple.Domain.Entities.Contracts.ContractStatus;
using Dr_Purple.Domain.Entities.Departments.Base;
using Dr_Purple.Domain.Entities.Payments.State;
using Dr_Purple.Domain.Entities.Payments;
using Dr_Purple.Domain.Entities.Reports;
using Dr_Purple.Domain.Entities.Users;
using Dr_Purple.Domain.Interfaces;
using System.Text.Json.Serialization;

namespace Dr_Purple.Domain.Entities.Contracts;
public partial class Contract : AuditableEntity, IEntity
{
    public long Id { get; private set; }
    public long UserId { get; private set; }
    public long JobTitleId { get; private set; }
    public long DepartmentId { get; private set; }
    public float Salary { get; private set; }
    public DateOnly StartDate { get; private set; }
    public DateOnly EndDate { get; private set; }
    public IContractState State { get; private set; }

    [JsonIgnore]
    public virtual JobTitle? JobTitle { get; private set; }

    [JsonIgnore]
    public virtual User? User { get; private set; }

    [JsonIgnore]
    public virtual Department? Department { get; private set; }

    [JsonIgnore]
    public virtual ICollection<ContractService> ContractServices { get; private set; } = new HashSet<ContractService>();

    [JsonIgnore]
    public virtual ICollection<Addition> Additions { get; private set; } = new HashSet<Addition>();

    [JsonIgnore]
    public virtual ICollection<Leave> Leaves { get; private set; } = new HashSet<Leave>();

    [JsonIgnore]
    public virtual ICollection<Attend> Attends { get; private set; } = new HashSet<Attend>();

    [JsonIgnore]
    public virtual ICollection<LeaveBalance> LeaveBalances { get; private set; } = new HashSet<LeaveBalance>();

    [JsonIgnore]
    public virtual ICollection<AppointmentPerContract> AppointmentsPerContract { get; private set; } = new HashSet<AppointmentPerContract>();


    protected Contract(long userId, long departmentId, long jobTitleId, float salary,
        DateOnly startDate, DateOnly endDate)
    {
        UserId = userId;
        DepartmentId = departmentId;
        JobTitleId = jobTitleId;
        Salary = salary;
        StartDate = startDate;
        EndDate = endDate;
        State = new NotActiveContractState();
    }

    public static Contract Create(long userId, long departmentId, long jobTitleId,
                 float salary, DateOnly startDate, DateOnly endDate)
    => new(userId, departmentId, jobTitleId, salary, startDate, endDate);

    public void Update(long userId, long departmentId, float salary, long jobTitleId,
        DateOnly startDate, DateOnly endDate)
    {
        UserId = userId;
        DepartmentId = departmentId;
        JobTitleId = jobTitleId;
        Salary = salary;
        StartDate = startDate;
        EndDate = endDate;
    }
    protected internal void SetState(IContractState state)
    => State = state;
}