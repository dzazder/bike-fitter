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
    public class StemsController : ControllerBase
    {
        private readonly BikeFitterContext _context;

        public StemsController(BikeFitterContext context)
        {
            _context = context;
        }

        // GET: api/Stems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stem>>> GetStems()
        {
          if (_context.Stems == null)
          {
              return NotFound();
          }
            return await _context.Stems.ToListAsync();
        }

        // GET: api/Stems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stem>> GetStem(int id)
        {
          if (_context.Stems == null)
          {
              return NotFound();
          }
            var stem = await _context.Stems.FindAsync(id);

            if (stem == null)
            {
                return NotFound();
            }

            return stem;
        }

        // PUT: api/Stems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStem(int id, Stem stem)
        {
            if (id != stem.Id)
            {
                return BadRequest();
            }

            _context.Entry(stem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StemExists(id))
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

        // POST: api/Stems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Stem>> PostStem(Stem stem)
        {
          if (_context.Stems == null)
          {
              return Problem("Entity set 'BikeFitterContext.Stems'  is null.");
          }
            _context.Stems.Add(stem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStem", new { id = stem.Id }, stem);
        }

        // DELETE: api/Stems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStem(int id)
        {
            if (_context.Stems == null)
            {
                return NotFound();
            }
            var stem = await _context.Stems.FindAsync(id);
            if (stem == null)
            {
                return NotFound();
            }

            _context.Stems.Remove(stem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StemExists(int id)
        {
            return (_context.Stems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
