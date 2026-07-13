using ErrorOr;
using MediatR;
using Trion.Application.Common.Interfaces;
using Trion.Domain.CoachAggregate;
using Trion.Domain.CoachAggregate.ValueObjects;

namespace Trion.Application.Coaches.Commands.DeleteCoach;

public sealed class DeleteCoachCommandHandler(
    ICoachRepository coachRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteCoachCommand, ErrorOr<Deleted>>
{
    public async Task<ErrorOr<Deleted>> Handle(DeleteCoachCommand request, CancellationToken cancellationToken)
    {
        var coachIdResult = CoachId.From(request.Id);

        var coachResult = await coachRepository.GetCoachByIdAsync(coachIdResult);

        if (coachResult is null)
        {
            return Error.NotFound();
        }

        coachRepository.RemoveCoach(coachResult);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Deleted;
    }
}