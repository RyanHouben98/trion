using ErrorOr;
using MediatR;
using Trion.Application.Common.Interfaces;
using Trion.Domain.AthleteAggregate;

namespace Trion.Application.Athletes.Commands.CreateAthlete;

public sealed class CreateAthleteCommandHandler(
    IAthleteRepository athleteRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateAthleteCommand, ErrorOr<Guid>>
{
    public async Task<ErrorOr<Guid>> Handle(CreateAthleteCommand request, CancellationToken cancellationToken)
    {
        var athleteResult = Athlete.Create(request.Name);

        athleteRepository.Add(athleteResult);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return athleteResult.Id.Value;
    }
}