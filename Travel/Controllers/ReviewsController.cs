using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travel.Models;
using System;
using Microsoft.AspNetCore.Http;


namespace Travel.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ReviewsController : ControllerBase
  {
    private readonly TravelContext _db;

    public ReviewsController(TravelContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Review>>> Get()
    {
      return await _db.Reviews.ToListAsync();
    }

    // GET api/Reviews/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Review>> GetReview(int id)
    {
      var review = await _db.Reviews.FindAsync(id);

    if (review == null)
    {
        return NotFound();
    }

    return review;
    }

    // POST api/Reviews
    [HttpPost]
    public async Task<ActionResult<Review>> Post(Review review)
    {
      _db.Reviews.Add(review);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetReview), new { id = review.ReviewId }, review);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Review review)
    {
        if (id != review.ReviewId)
        {
            return BadRequest();
        }

        _db.Entry(review).State = EntityState.Modified;

        try
        {
            await _db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ReviewExists(id))
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
    private bool ReviewExists(int id)
    {
        return _db.Reviews.Any(e => e.ReviewId == id);
    }

        // DELETE: api/Reviews/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReview(int id)
    {
      var review = await _db.Reviews.FindAsync(id);
      if (review == null)
      {
        return NotFound();
      }

      _db.Reviews.Remove(review);
      await _db.SaveChangesAsync();

      return NoContent();
    }

  }
}
