using ErrorOr;
using MediatR;
using Trion.Domain.CoachAggregate;

namespace Trion.Application.Coaches.Queries.ListCoaches;

public sealed class ListCoachesQueryHandler(ICoachRepository coachRepository) : IRequestHandler<ListCoachesQuery, ErrorOr<List<Coach>>>
{
    public async Task<ErrorOr<List<Coach>>> Handle(ListCoachesQuery request, CancellationToken cancellationToken)
    {
        var coaches = await coachRepository.ListCoachesAsync();

        return coaches.ToList();
    }
}