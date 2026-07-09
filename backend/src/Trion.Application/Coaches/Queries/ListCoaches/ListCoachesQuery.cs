using ErrorOr;
using MediatR;
using Trion.Domain.CoachAggregate;

namespace Trion.Application.Coaches.Queries.ListCoaches;

public sealed record ListCoachesQuery() 
    : IRequest<ErrorOr<List<Coach>>>;