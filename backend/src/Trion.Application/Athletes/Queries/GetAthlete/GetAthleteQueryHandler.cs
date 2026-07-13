using ErrorOr;
using MediatR;
using Trion.Application.Common.Interfaces;
using Trion.Domain.AthleteAggregate;
using Trion.Domain.AthleteAggregate.ValueObjects;

namespace Trion.Application.Athletes.Queries.GetAthlete;

public sealed class GetAthleteQueryHandler(
    IAthleteRepository athleteRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<GetAthleteQuery, ErrorOr<Athlete>>
{
    public async Task<ErrorOr<Athlete>> Handle(GetAthleteQuery request, CancellationToken cancellationToken)
    {
        var athleteIdResult = AthleteId.From(request.Id);

        var athleteResult = await athleteRepository.GetByIdAsync(athleteIdResult);

        if (athleteResult is null)
        {
            return Error.NotFound();
        }
        
        return athleteResult;
    }
}