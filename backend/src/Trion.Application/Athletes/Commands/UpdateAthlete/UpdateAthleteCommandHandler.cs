using ErrorOr;
using MediatR;
using Trion.Application.Common.Interfaces;
using Trion.Domain.AthleteAggregate;
using Trion.Domain.AthleteAggregate.ValueObjects;

namespace Trion.Application.Athletes.Commands.UpdateAthlete;

public sealed class UpdateAthleteCommandHandler(
    IAthleteRepository athleteRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateAthleteCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(UpdateAthleteCommand request, CancellationToken cancellationToken)
    {
        var athleteIdResult = AthleteId.From(request.Id);

        var athleteResult = await athleteRepository.GetByIdAsync(athleteIdResult);

        if (athleteResult is null)
        {
            return Error.NotFound();
        }
        
        athleteResult.Update(request.Name);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Updated;
    }
}