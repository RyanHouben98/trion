using MediatR;
using Microsoft.AspNetCore.Mvc;
using Trion.Application.Coaches.Queries.GetCoach;
using Trion.Application.Coaches.Queries.ListCoaches;
using Trion.Contracts.CoachContracts;
using Trion.Domain.CoachAggregate;
using Trion.Domain.CoachAggregate.ValueObjects;
using Trion.Infrastructure.Persistence;

namespace Trion.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CoachesController(ApplicationDbContext dbContext, ISender sender) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var query = new GetCoachQuery(id);

        var result = await sender.Send(query);

        return result.Match(
            okResult => Ok(okResult),
            _ => Problem());
    }
    
    [HttpGet]
    public async Task<IActionResult> List()
    {
        var query = new ListCoachesQuery();
        
        var result = await sender.Send(query);

        return result.Match(
            okResult => Ok(okResult),
            _ => Problem());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCoachRequest request)
    {
        var coach = Coach.Create(request.Name);
        
        await dbContext.Coaches.AddAsync(coach);
        
        await dbContext.SaveChangesAsync();
        
        return Created(nameof(Get), new { id = coach.Id });
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        [FromRoute] Guid id,
        [FromBody] UpdateCoachRequest request)
    {
        var coachId = CoachId.From(id);
        var coach = await dbContext.Coaches.FindAsync(coachId);
        
        if (coach is null)
            return NotFound();
        
        coach.Update(request.Name);
        
        await  dbContext.SaveChangesAsync();
        
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task <IActionResult> Delete([FromRoute] Guid id)
    {
        var coachId = CoachId.From(id);
        var coach = await dbContext.Coaches.FindAsync(coachId);
        
        if (coach is null)
            return NotFound();
        
        dbContext.Coaches.Remove(coach);
        
        await dbContext.SaveChangesAsync();
        
        return NoContent();
    }
}