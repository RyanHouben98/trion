using ErrorOr;
using MediatR;
using Trion.Domain.CoachAggregate;

namespace Trion.Application.Coaches.Queries.GetCoach;

public sealed record GetCoachQuery(
    Guid Id) : IRequest<ErrorOr<Coach>>;