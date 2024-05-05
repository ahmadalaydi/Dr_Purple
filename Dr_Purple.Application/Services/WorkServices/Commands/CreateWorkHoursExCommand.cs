using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.WorkServices.Commands;

public record CreateWorkHoursExceptionCommand(string Name, DateTime StartDate, DateTime EndDate) : IRequest<IResult>;