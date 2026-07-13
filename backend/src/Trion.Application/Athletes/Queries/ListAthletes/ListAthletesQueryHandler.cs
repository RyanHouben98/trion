using ErrorOr;
using MediatR;
using Trion.Application.Common.Interfaces;
using Trion.Domain.AthleteAggregate;

namespace Trion.Application.Athletes.Queries.ListAthletes;

public sealed class ListAthletesQueryHandler(
    IAthleteRepository athleteRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<ListAthletesQuery, ErrorOr<List<Athlete>>>
{
    public async Task<ErrorOr<List<Athlete>>> Handle(ListAthletesQuery request, CancellationToken cancellationToken)
    {
        var athletes = await athleteRepository.ListAsync();

        return athletes.ToList();
    }
}