using ErrorOr;
using MediatR;
using Trion.Application.Common.Interfaces;
using Trion.Domain.AthleteAggregate;
using Trion.Domain.AthleteAggregate.ValueObjects;

namespace Trion.Application.Athletes.Commands.DeleteAthlete;

public sealed class DeleteAthleteCommandHandler(
    IAthleteRepository athleteRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteAthleteCommand, ErrorOr<Deleted>>
{
    public async Task<ErrorOr<Deleted>> Handle(DeleteAthleteCommand request, CancellationToken cancellationToken)
    {
        var athleteIdResult = AthleteId.From(request.Id);

        var athleteResult = await athleteRepository.GetByIdAsync(athleteIdResult);

        if (athleteResult is null)
        {
            return Error.NotFound();
        }
        
        athleteRepository.Remove(athleteResult);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Deleted;
    }
}