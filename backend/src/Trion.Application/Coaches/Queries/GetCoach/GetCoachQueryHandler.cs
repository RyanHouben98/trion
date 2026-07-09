using ErrorOr;
using MediatR;
using Trion.Domain.CoachAggregate;
using Trion.Domain.CoachAggregate.ValueObjects;

namespace Trion.Application.Coaches.Queries.GetCoach;

public sealed class GetCoachQueryHandler(ICoachRepository coachRepository) : IRequestHandler<GetCoachQuery, ErrorOr<Coach>>
{
    public async Task<ErrorOr<Coach>> Handle(GetCoachQuery request, CancellationToken cancellationToken)
    {
        var coachIdResult = CoachId.From(request.Id);

        var coach = await coachRepository.GetCoachByIdAsync(coachIdResult);

        if (coach is null)
        {
            return Error.NotFound();
        }
        
        return coach;
    }
}