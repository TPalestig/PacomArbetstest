using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PacomArbetstest.Data;

[ApiController]
[Route("api/[controller]")]
public class ToggleStatesController : ControllerBase
{
    private readonly PacomDbContext _context;

    public ToggleStatesController(PacomDbContext context)
    {
        _context = context;
    }

    // GET: api/togglestates/1
    //[HttpGet("{id}")]
    [HttpGet("{coilAddress}")]
    public async Task<ActionResult<ToggleState>> GetToggleState(int coilAddress)//int id)
    {
        var toggleState = _context.ToggleStates.Where(q => q.CoilAddress == coilAddress).SingleOrDefault();
        if (toggleState == null)
        {
            return NotFound();
        }

        return toggleState;
    }

    // POST: api/togglestates
    [HttpPost]
    public async Task<ActionResult<ToggleState>> CreateToggleState(ToggleState toggleState)
    {
        _context.ToggleStates.Add(toggleState);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetToggleState), new { id = toggleState.Id }, toggleState);
    }

    // PUT: api/togglestates/1
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateToggleState(int id, ToggleState toggleState)
    {
        if (id != toggleState.Id)
            return BadRequest();

        _context.Entry(toggleState).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.ToggleStates.Any(e => e.Id == id))
                return NotFound();
            throw;
        }
        return NoContent();
    }

    // DELETE: api/togglestates/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteToggleState(int id)
    {
        var toggleState = await _context.ToggleStates.FindAsync(id);
        if (toggleState == null)
            return NotFound();

        _context.ToggleStates.Remove(toggleState);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}