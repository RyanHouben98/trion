using ErrorOr;
using MediatR;

namespace Trion.Application.Coaches.Commands.UpdateCoach;

public sealed record UpdateCoachCommand(
    Guid Id,
    string Name) : IRequest<ErrorOr<Updated>>;