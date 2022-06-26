using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BikeFitter.Api.Context;
using BikeFitter.Models.Models;
using BikeFitter.Models.ApiModel;

namespace BikeFitter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikesController : ControllerBase
    {
        private readonly BikeFitterContext _context;

        public BikesController(BikeFitterContext context)
        {
            _context = context;
        }

        // GET: api/Bikes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bike>>> GetBikes()
        {
            if (_context.Bikes == null)
            {
                return NotFound();
            }
            return await _context.Bikes.ToListAsync();
        }

        // GET: api/Bikes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bike>> GetBike(int id)
        {
            if (_context.Bikes == null)
            {
                return NotFound();
            }
            var bike = await _context.Bikes.FindAsync(id);

            if (bike == null)
            {
                return NotFound();
            }

            return bike;
        }

        // PUT: api/Bikes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBike(int id, ApiBike apiBike)
        {
            Bike bike = CreateBike(apiBike);
            if (id != bike.Id)
            {
                return BadRequest();
            }

            _context.Entry(bike).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BikeExists(id))
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

        // POST: api/Bikes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bike>> PostBike(ApiBike apiBike)
        {
            if (_context.Bikes == null)
            {
                return Problem("Entity set 'BikeFitterContext.Bikes'  is null.");
            }
            Bike bike = CreateBike(apiBike);
            _context.Bikes.Add(bike);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBike", new { id = bike.Id }, bike);
        }

        // DELETE: api/Bikes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBike(int id)
        {
            if (_context.Bikes == null)
            {
                return NotFound();
            }
            var bike = await _context.Bikes.FindAsync(id);
            if (bike == null)
            {
                return NotFound();
            }

            _context.Bikes.Remove(bike);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BikeExists(int id)
        {
            return (_context.Bikes?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private Bike CreateBike(ApiBike apiBike)
        {
            try
            {
                Bike bike = new Bike
                {
                    Id = apiBike.Id,
                    ModelName = apiBike.ModelName,
                    Price = apiBike.Price,
                    Uri = apiBike.Uri,
                    Weight = apiBike.Weight,
                    Brakes = _context.Brakes.FirstOrDefault(x => x.Id == apiBike.BrakesId),
                    Cassette = _context.Cassettes.FirstOrDefault(x => x.Id == apiBike.CassetteId),
                    Derailleur = _context.Derailleurs.FirstOrDefault(x => x.Id == apiBike.DerailleurId),
                    Crankset = _context.Cranksets.FirstOrDefault(x => x.Id == apiBike.CranksetId),
                    Fork = _context.Forks.FirstOrDefault(x => x.Id == apiBike.ForkId),
                    Manufacturer = _context.Manufacturers.FirstOrDefault(x => x.Id == apiBike.ManufacturerId),
                    Rims = _context.Rims.FirstOrDefault(x => x.Id == apiBike.RimsId),
                    Shifter = _context.Shifters.FirstOrDefault(x => x.Id == apiBike.ShifterId),
                    Stem = _context.Stems.FirstOrDefault(x => x.Id == apiBike.StemId),
                    Tires = _context.Tires.FirstOrDefault(x => x.Id == apiBike.TiresId)
                };

                return bike;
            }
            catch (Exception)
            {
                
            }

            return null;
        }
    }
}
