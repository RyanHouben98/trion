using MediatR;
using Microsoft.AspNetCore.Mvc;
using Trion.Application.Coaches.Commands.CreateCoach;
using Trion.Application.Coaches.Commands.DeleteCoach;
using Trion.Application.Coaches.Commands.UpdateCoach;
using Trion.Application.Coaches.Queries.GetCoach;
using Trion.Application.Coaches.Queries.ListCoaches;
using Trion.Contracts.CoachContracts;

namespace Trion.WebApi.Controllers;

[Route("[controller]")]
public class CoachesController(ISender sender) : ApiController
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var query = new GetCoachQuery(id);

        var result = await sender.Send(query);

        return ToActionResult(result, Ok);
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var query = new ListCoachesQuery();
        
        var result = await sender.Send(query);

        return ToActionResult(result, Ok);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCoachRequest request)
    {
        var command = new CreateCoachCommand(request.Name);
        
        var result = await sender.Send(command);

        return ToActionResult(result, value => Created(nameof(Get), value));
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        [FromRoute] Guid id,
        [FromBody] UpdateCoachRequest request)
    {
        var command = new UpdateCoachCommand(id, request.Name);
        
        var result = await sender.Send(command);
        
        return ToActionResult(result, _ => NoContent());
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var command = new DeleteCoachCommand(id);

        var result = await sender.Send(command);

        return ToActionResult(result, _ => NoContent());
    }
}