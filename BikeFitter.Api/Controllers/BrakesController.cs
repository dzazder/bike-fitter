using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BikeFitter.Api.Context;
using BikeFitter.Models.Models;

namespace BikeFitter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrakesController : ControllerBase
    {
        private readonly BikeFitterContext _context;

        public BrakesController(BikeFitterContext context)
        {
            _context = context;
        }

        // GET: api/Brakes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brake>>> GetBrakes()
        {
          if (_context.Brakes == null)
          {
              return NotFound();
          }
            return await _context.Brakes.ToListAsync();
        }

        // GET: api/Brakes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Brake>> GetBrake(int id)
        {
          if (_context.Brakes == null)
          {
              return NotFound();
          }
            var brake = await _context.Brakes.FindAsync(id);

            if (brake == null)
            {
                return NotFound();
            }

            return brake;
        }

        // PUT: api/Brakes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrake(int id, Brake brake)
        {
            if (id != brake.Id)
            {
                return BadRequest();
            }

            _context.Entry(brake).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrakeExists(id))
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

        // POST: api/Brakes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Brake>> PostBrake(Brake brake)
        {
          if (_context.Brakes == null)
          {
              return Problem("Entity set 'BikeFitterContext.Brakes'  is null.");
          }
            _context.Brakes.Add(brake);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBrake", new { id = brake.Id }, brake);
        }

        // DELETE: api/Brakes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrake(int id)
        {
            if (_context.Brakes == null)
            {
                return NotFound();
            }
            var brake = await _context.Brakes.FindAsync(id);
            if (brake == null)
            {
                return NotFound();
            }

            _context.Brakes.Remove(brake);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BrakeExists(int id)
        {
            return (_context.Brakes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
