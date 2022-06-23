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
    public class ShiftersController : ControllerBase
    {
        private readonly BikeFitterContext _context;

        public ShiftersController(BikeFitterContext context)
        {
            _context = context;
        }

        // GET: api/Shifters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shifter>>> GetShifters()
        {
          if (_context.Shifters == null)
          {
              return NotFound();
          }
            return await _context.Shifters.ToListAsync();
        }

        // GET: api/Shifters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shifter>> GetShifter(int id)
        {
          if (_context.Shifters == null)
          {
              return NotFound();
          }
            var shifter = await _context.Shifters.FindAsync(id);

            if (shifter == null)
            {
                return NotFound();
            }

            return shifter;
        }

        // PUT: api/Shifters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShifter(int id, Shifter shifter)
        {
            if (id != shifter.Id)
            {
                return BadRequest();
            }

            _context.Entry(shifter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShifterExists(id))
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

        // POST: api/Shifters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Shifter>> PostShifter(Shifter shifter)
        {
          if (_context.Shifters == null)
          {
              return Problem("Entity set 'BikeFitterContext.Shifters'  is null.");
          }
            _context.Shifters.Add(shifter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShifter", new { id = shifter.Id }, shifter);
        }

        // DELETE: api/Shifters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShifter(int id)
        {
            if (_context.Shifters == null)
            {
                return NotFound();
            }
            var shifter = await _context.Shifters.FindAsync(id);
            if (shifter == null)
            {
                return NotFound();
            }

            _context.Shifters.Remove(shifter);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShifterExists(int id)
        {
            return (_context.Shifters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
