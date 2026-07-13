using ErrorOr;
using MediatR;

namespace Trion.Application.Athletes.Commands.UpdateAthlete;

public sealed record UpdateAthleteCommand(
    Guid Id,
    string Name) : IRequest<ErrorOr<Updated>>;