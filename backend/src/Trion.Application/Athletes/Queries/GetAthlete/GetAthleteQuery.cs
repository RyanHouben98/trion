using ErrorOr;
using MediatR;
using Trion.Domain.AthleteAggregate;

namespace Trion.Application.Athletes.Queries.GetAthlete;

public sealed record GetAthleteQuery(
    Guid Id) : IRequest<ErrorOr<Athlete>>;