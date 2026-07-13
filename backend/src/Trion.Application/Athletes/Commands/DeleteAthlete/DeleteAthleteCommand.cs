using ErrorOr;
using MediatR;

namespace Trion.Application.Athletes.Commands.DeleteAthlete;

public sealed record DeleteAthleteCommand(
    Guid Id) : IRequest<ErrorOr<Deleted>>;