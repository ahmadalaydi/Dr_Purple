using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.WorkServices.Commands;

public record UpdateHolidayCommand(string Name, DateOnly Date) : IRequest<IResult>
{
    public long Id { get; init; }
}