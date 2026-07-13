using ErrorOr;
using MediatR;
using Trion.Application.Common.Interfaces;
using Trion.Domain.CoachAggregate;

namespace Trion.Application.Coaches.Commands.CreateCoach;

public sealed class CreateCoachCommandHandler(
    ICoachRepository coachRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateCoachCommand, ErrorOr<Guid>>
{
    public async Task<ErrorOr<Guid>> Handle(CreateCoachCommand request, CancellationToken cancellationToken)
    {
        var coachResult = Coach.Create(request.Name);
        
        coachRepository.AddCoach(coachResult);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return coachResult.Id.Value;
    }
}