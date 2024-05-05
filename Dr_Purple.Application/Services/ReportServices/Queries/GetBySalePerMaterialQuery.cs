using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.ReportServices.Queries;

public record GetBySalePerMaterialQuery(DateOnly From, DateOnly To) : IRequest<IResult>;