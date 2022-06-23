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
    public class DerailleursController : ControllerBase
    {
        private readonly BikeFitterContext _context;

        public DerailleursController(BikeFitterContext context)
        {
            _context = context;
        }

        // GET: api/Derailleurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Derailleur>>> GetDerailleurs()
        {
          if (_context.Derailleurs == null)
          {
              return NotFound();
          }
            return await _context.Derailleurs.ToListAsync();
        }

        // GET: api/Derailleurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Derailleur>> GetDerailleur(int id)
        {
          if (_context.Derailleurs == null)
          {
              return NotFound();
          }
            var derailleur = await _context.Derailleurs.FindAsync(id);

            if (derailleur == null)
            {
                return NotFound();
            }

            return derailleur;
        }

        // PUT: api/Derailleurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDerailleur(int id, Derailleur derailleur)
        {
            if (id != derailleur.Id)
            {
                return BadRequest();
            }

            _context.Entry(derailleur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DerailleurExists(id))
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

        // POST: api/Derailleurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Derailleur>> PostDerailleur(Derailleur derailleur)
        {
          if (_context.Derailleurs == null)
          {
              return Problem("Entity set 'BikeFitterContext.Derailleurs'  is null.");
          }
            _context.Derailleurs.Add(derailleur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDerailleur", new { id = derailleur.Id }, derailleur);
        }

        // DELETE: api/Derailleurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDerailleur(int id)
        {
            if (_context.Derailleurs == null)
            {
                return NotFound();
            }
            var derailleur = await _context.Derailleurs.FindAsync(id);
            if (derailleur == null)
            {
                return NotFound();
            }

            _context.Derailleurs.Remove(derailleur);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DerailleurExists(int id)
        {
            return (_context.Derailleurs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
