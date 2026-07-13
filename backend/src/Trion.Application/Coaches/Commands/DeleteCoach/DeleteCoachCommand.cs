using ErrorOr;
using MediatR;

namespace Trion.Application.Coaches.Commands.DeleteCoach;

public sealed record DeleteCoachCommand(
    Guid Id) : IRequest<ErrorOr<Deleted>>;