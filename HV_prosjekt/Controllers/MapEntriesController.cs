using HV_prosjekt.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace HV_prosjekt.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MapEntriesController : ControllerBase
{
    // simple in-memory store
    private static readonly ConcurrentDictionary<int, GeoEntry> _store = new();
    private static int _nextId = 1;

    [HttpGet]
    public IActionResult GetAll()
    {
        var values = _store.Values.OrderBy(e => e.CreatedAt).ToList();
        return Ok(values);
    }

    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        if (_store.TryGetValue(id, out var entry)) return Ok(entry);
        return NotFound();
    }

    public record CreateRequest(string Title, string GeoJson);

    [HttpPost]
    public IActionResult Create([FromBody] CreateRequest req)
    {
        if (req is null || string.IsNullOrWhiteSpace(req.GeoJson)) return BadRequest();
        var id = Interlocked.Increment(ref _nextId);
        var entry = new GeoEntry(id, req.Title ?? string.Empty, req.GeoJson, DateTime.UtcNow);
        _store[entry.Id] = entry;
        return CreatedAtAction(nameof(Get), new { id = entry.Id }, entry);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        if (_store.TryRemove(id, out _)) return NoContent();
        return NotFound();
    }
}
