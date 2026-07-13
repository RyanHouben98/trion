using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace Trion.WebApi.Controllers;

[ApiController]
public abstract class ApiController : ControllerBase
{
    protected IActionResult ToActionResult<T>(ErrorOr<T> result, Func<T, IActionResult> onValue) =>
        result.Match(onValue, ToProblemResult);
    
    private IActionResult ToProblemResult(List<Error> errors)
    {
        var first = errors.First();
        return first.Type switch
        {
            ErrorType.NotFound => NotFound(first.Description),
            ErrorType.Validation => BadRequest(first.Description),
            ErrorType.Conflict => Conflict(first.Description),
            _ => Problem(first.Description)
        };
    }
}