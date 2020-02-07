using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IP_Final_3975.Models;

namespace IP_Final_3975.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportsController : ControllerBase
    {
        private readonly IPFinalContext _context;

        public SportsController(IPFinalContext context)
        {
            _context = context;
        }

        // GET: api/Sports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sport>>> GetSport()
        {
            return await _context.Sport.ToListAsync();
        }

        // GET: api/Sports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sport>> GetSport(int id)
        {
            var sport = await _context.Sport.FindAsync(id);

            if (sport == null)
            {
                return NotFound();
            }

            return sport;
        }

        // PUT: api/Sports/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSport(int id, Sport sport)
        {
            if (id != sport.SportId)
            {
                return BadRequest();
            }

            _context.Entry(sport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SportExists(id))
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

        // POST: api/Sports
        [HttpPost]
        public async Task<ActionResult<Sport>> PostSport(Sport sport)
        {
            _context.Sport.Add(sport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSport", new { id = sport.SportId }, sport);
        }

        // DELETE: api/Sports/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sport>> DeleteSport(int id)
        {
            var sport = await _context.Sport.FindAsync(id);
            if (sport == null)
            {
                return NotFound();
            }

            _context.Sport.Remove(sport);
            await _context.SaveChangesAsync();

            return sport;
        }

        private bool SportExists(int id)
        {
            return _context.Sport.Any(e => e.SportId == id);
        }
    }
}
