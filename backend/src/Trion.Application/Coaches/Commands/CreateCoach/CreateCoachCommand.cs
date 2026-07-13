using ErrorOr;
using MediatR;

namespace Trion.Application.Coaches.Commands.CreateCoach;

public sealed record CreateCoachCommand(
    string Name) : IRequest<ErrorOr<Guid>>;