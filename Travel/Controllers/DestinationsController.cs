using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travel.Models;

namespace Travel.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DestinationsController : Controller
  {
    private readonly TravelContext _context;
    
    public DestinationsController(TravelContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Destination>>> GetDestinations()
    {
      return await _context.Destinations.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Destination>> GetDestination(int id)
    {
      var destination = await _context.Destinations.FindAsync(id);
      
      if (destination == null)
      {
        return NotFound();
      }

      return destination;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutDestination(int id, Destination destination)
    {
      if (id != destination.DestinationId)
      {
        return BadRequest();
      }

      _context.Entry(destination).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!DestinationExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<Destination>> PostDestination(Destination destination)
    {
      _context.Destinations.Add(destination);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetDestination", new { id = destination.DestinationId }, destination);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDestination(int id)
    {
      var destination = await _context.Destinations.FindAsync(id);
      if (destination == null)
      {
        return NotFound();
      }

      _context.Destinations.Remove(destination);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool DestinationExists(int id)
    {
      return _context.Destinations.Any(e => e.DestinationId == id);
    }

    [HttpGet("search/")]
    public async Task<ActionResult<IEnumerable<Destination>>> Search(string name)
    {
      var query = _context.Destinations.AsQueryable();

      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }

      return await query.ToListAsync();
    }
  }

}
