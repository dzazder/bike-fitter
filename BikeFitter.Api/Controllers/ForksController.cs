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
    public class ForksController : ControllerBase
    {
        private readonly BikeFitterContext _context;

        public ForksController(BikeFitterContext context)
        {
            _context = context;
        }

        // GET: api/Forks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fork>>> GetForks()
        {
          if (_context.Forks == null)
          {
              return NotFound();
          }
            return await _context.Forks.ToListAsync();
        }

        // GET: api/Forks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fork>> GetFork(int id)
        {
          if (_context.Forks == null)
          {
              return NotFound();
          }
            var fork = await _context.Forks.FindAsync(id);

            if (fork == null)
            {
                return NotFound();
            }

            return fork;
        }

        // PUT: api/Forks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFork(int id, Fork fork)
        {
            if (id != fork.Id)
            {
                return BadRequest();
            }

            _context.Entry(fork).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ForkExists(id))
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

        // POST: api/Forks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fork>> PostFork(Fork fork)
        {
          if (_context.Forks == null)
          {
              return Problem("Entity set 'BikeFitterContext.Forks'  is null.");
          }
            _context.Forks.Add(fork);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFork", new { id = fork.Id }, fork);
        }

        // DELETE: api/Forks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFork(int id)
        {
            if (_context.Forks == null)
            {
                return NotFound();
            }
            var fork = await _context.Forks.FindAsync(id);
            if (fork == null)
            {
                return NotFound();
            }

            _context.Forks.Remove(fork);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ForkExists(int id)
        {
            return (_context.Forks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
