using ErrorOr;
using MediatR;
using Trion.Domain.AthleteAggregate;

namespace Trion.Application.Athletes.Queries.ListAthletes;

public sealed record ListAthletesQuery()
    : IRequest<ErrorOr<List<Athlete>>>;