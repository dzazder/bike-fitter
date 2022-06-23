using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BikeFitter.Api.Context;
using BikeFitter.Api.Models;

namespace BikeFitter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RimsController : ControllerBase
    {
        private readonly BikeFitterContext _context;

        public RimsController(BikeFitterContext context)
        {
            _context = context;
        }

        // GET: api/Rims
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rim>>> GetRims()
        {
          if (_context.Rims == null)
          {
              return NotFound();
          }
            return await _context.Rims.ToListAsync();
        }

        // GET: api/Rims/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rim>> GetRim(int id)
        {
          if (_context.Rims == null)
          {
              return NotFound();
          }
            var rim = await _context.Rims.FindAsync(id);

            if (rim == null)
            {
                return NotFound();
            }

            return rim;
        }

        // PUT: api/Rims/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRim(int id, Rim rim)
        {
            if (id != rim.Id)
            {
                return BadRequest();
            }

            _context.Entry(rim).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RimExists(id))
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

        // POST: api/Rims
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rim>> PostRim(Rim rim)
        {
          if (_context.Rims == null)
          {
              return Problem("Entity set 'BikeFitterContext.Rims'  is null.");
          }
            _context.Rims.Add(rim);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRim", new { id = rim.Id }, rim);
        }

        // DELETE: api/Rims/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRim(int id)
        {
            if (_context.Rims == null)
            {
                return NotFound();
            }
            var rim = await _context.Rims.FindAsync(id);
            if (rim == null)
            {
                return NotFound();
            }

            _context.Rims.Remove(rim);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RimExists(int id)
        {
            return (_context.Rims?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
