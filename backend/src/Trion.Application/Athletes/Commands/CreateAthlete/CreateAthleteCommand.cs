using ErrorOr;
using MediatR;

namespace Trion.Application.Athletes.Commands.CreateAthlete;

public sealed record CreateAthleteCommand(
    string Name) : IRequest<ErrorOr<Guid>>;