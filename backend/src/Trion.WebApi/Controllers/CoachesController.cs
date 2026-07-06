using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trion.Contracts.CoachContracts;
using Trion.Domain.CoachAggregate;
using Trion.Domain.CoachAggregate.ValueObjects;
using Trion.Infrastructure.Persistence;

namespace Trion.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CoachesController(ApplicationDbContext dbContext) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var coachId = CoachId.From(id);
        var coach = await dbContext.Coaches.FindAsync(coachId);
        
        if (coach is null)
            return NotFound();
        
        return Ok(coach);
    }
    
    [HttpGet]
    public async Task<IActionResult> List()
    {
        var coaches = await dbContext.Coaches.ToListAsync();
        
        return Ok(coaches);
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