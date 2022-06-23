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
    public class CassettesController : ControllerBase
    {
        private readonly BikeFitterContext _context;

        public CassettesController(BikeFitterContext context)
        {
            _context = context;
        }

        // GET: api/Cassettes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cassette>>> GetCassettes()
        {
          if (_context.Cassettes == null)
          {
              return NotFound();
          }
            return await _context.Cassettes.ToListAsync();
        }

        // GET: api/Cassettes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cassette>> GetCassette(int id)
        {
          if (_context.Cassettes == null)
          {
              return NotFound();
          }
            var cassette = await _context.Cassettes.FindAsync(id);

            if (cassette == null)
            {
                return NotFound();
            }

            return cassette;
        }

        // PUT: api/Cassettes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCassette(int id, Cassette cassette)
        {
            if (id != cassette.Id)
            {
                return BadRequest();
            }

            _context.Entry(cassette).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CassetteExists(id))
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

        // POST: api/Cassettes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cassette>> PostCassette(Cassette cassette)
        {
          if (_context.Cassettes == null)
          {
              return Problem("Entity set 'BikeFitterContext.Cassettes'  is null.");
          }
            _context.Cassettes.Add(cassette);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCassette", new { id = cassette.Id }, cassette);
        }

        // DELETE: api/Cassettes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCassette(int id)
        {
            if (_context.Cassettes == null)
            {
                return NotFound();
            }
            var cassette = await _context.Cassettes.FindAsync(id);
            if (cassette == null)
            {
                return NotFound();
            }

            _context.Cassettes.Remove(cassette);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CassetteExists(int id)
        {
            return (_context.Cassettes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
