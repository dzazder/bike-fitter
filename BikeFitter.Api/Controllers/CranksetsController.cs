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
    public class CranksetsController : ControllerBase
    {
        private readonly BikeFitterContext _context;

        public CranksetsController(BikeFitterContext context)
        {
            _context = context;
        }

        // GET: api/Cranksets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Crankset>>> GetCranksets()
        {
          if (_context.Cranksets == null)
          {
              return NotFound();
          }
            return await _context.Cranksets.ToListAsync();
        }

        // GET: api/Cranksets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Crankset>> GetCrankset(int id)
        {
          if (_context.Cranksets == null)
          {
              return NotFound();
          }
            var crankset = await _context.Cranksets.FindAsync(id);

            if (crankset == null)
            {
                return NotFound();
            }

            return crankset;
        }

        // PUT: api/Cranksets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCrankset(int id, Crankset crankset)
        {
            if (id != crankset.Id)
            {
                return BadRequest();
            }

            _context.Entry(crankset).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CranksetExists(id))
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

        // POST: api/Cranksets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Crankset>> PostCrankset(Crankset crankset)
        {
          if (_context.Cranksets == null)
          {
              return Problem("Entity set 'BikeFitterContext.Cranksets'  is null.");
          }
            _context.Cranksets.Add(crankset);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCrankset", new { id = crankset.Id }, crankset);
        }

        // DELETE: api/Cranksets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCrankset(int id)
        {
            if (_context.Cranksets == null)
            {
                return NotFound();
            }
            var crankset = await _context.Cranksets.FindAsync(id);
            if (crankset == null)
            {
                return NotFound();
            }

            _context.Cranksets.Remove(crankset);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CranksetExists(int id)
        {
            return (_context.Cranksets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
