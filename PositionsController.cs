using HV_prosjekt.DataAccess;
using HV_prosjekt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HV_prosjekt.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PositionsController : ControllerBase
{
    private readonly HV_prosjektDbContext _db;

    public PositionsController(HV_prosjektDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var positions = await _db.Positions
            .AsNoTracking()
            .OrderBy(p => p.CreatedAt)
            .Select(p => new { p.Id, p.Latitude, p.Longitude, p.CreatedAt })
            .ToListAsync();

        return Ok(positions);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var p = await _db.Positions.FindAsync(id);
        if (p is null) return NotFound();
        return Ok(new { p.Id, p.Latitude, p.Longitude, p.CreatedAt });
    }

    // Allow JSON POST from JS; skip antiforgery for this API endpoint
    [HttpPost]
   
    public async Task<IActionResult> Create([FromBody] PositionDto range)
    {
        if (range is null) return BadRequest();
        var pos = new Position
        {
            Latitude = range.Latitude,
            Longitude = range.Longitude,
            CreatedAt = DateTime.UtcNow
        };
        _db.Positions.Add(pos);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = pos.Id }, new { pos.Id, pos.Latitude, pos.Longitude, pos.CreatedAt });
    }

    public record PositionDto(double Latitude, double Longitude);
}
