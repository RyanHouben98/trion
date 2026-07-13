using MediatR;
using Microsoft.AspNetCore.Mvc;
using Trion.Application.Athletes.Commands.CreateAthlete;
using Trion.Application.Athletes.Commands.DeleteAthlete;
using Trion.Application.Athletes.Commands.UpdateAthlete;
using Trion.Application.Athletes.Queries.GetAthlete;
using Trion.Application.Athletes.Queries.ListAthletes;
using Trion.Contracts.AthleteContracts;

namespace Trion.WebApi.Controllers;

[Route("api/[controller]")]
public sealed class AthletesController(ISender sender) : ApiController
{
    [HttpGet]
    public async Task<IActionResult> List()
    {
        var query = new ListAthletesQuery();

        var result = await sender.Send(query);
        
        return ToActionResult(result, Ok);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var query = new GetAthleteQuery(id);
        
        var result = await sender.Send(query);
        
        return ToActionResult(result, Ok);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody]  CreateAthleteRequest request)
    {
        var command = new CreateAthleteCommand(request.Name);
        
        var result = await sender.Send(command);
        
        return ToActionResult(result, value => Created(nameof(Get), value));
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        [FromRoute] Guid id,
        [FromBody]  UpdateAthleteRequest request)
    {
        var command = new UpdateAthleteCommand(id, request.Name);
        
        var result = await sender.Send(command);
        
        return ToActionResult(result, value => NoContent());
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var command = new DeleteAthleteCommand(id);

        var result = await sender.Send(command);
        
        return ToActionResult(result, _ => NoContent());
    }
}