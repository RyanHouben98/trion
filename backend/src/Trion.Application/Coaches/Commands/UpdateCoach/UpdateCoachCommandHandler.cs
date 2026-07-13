using ErrorOr;
using MediatR;
using Trion.Application.Common.Interfaces;
using Trion.Domain.CoachAggregate;
using Trion.Domain.CoachAggregate.ValueObjects;

namespace Trion.Application.Coaches.Commands.UpdateCoach;

public sealed class UpdateCoachCommandHandler(
    ICoachRepository coachRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateCoachCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(UpdateCoachCommand request, CancellationToken cancellationToken)
    {
        var coachIdResult = CoachId.From(request.Id);

        var coachResult = await coachRepository.GetCoachByIdAsync(coachIdResult);

        if (coachResult is null)
        {
            return Error.NotFound();
        }
        
        coachResult.Update(request.Name);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Updated;
    }
}