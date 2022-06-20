using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BikeFitter;
using BikeFitter.Models;

namespace BikeFitter.Pages.Bikes
{
    public class DetailsModel : PageModel
    {
        private readonly BikeFitter.BikeFitterContext _context;

        public DetailsModel(BikeFitter.BikeFitterContext context)
        {
            _context = context;
        }

      public Bike Bike { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Bikes == null)
            {
                return NotFound();
            }

            var bike = await _context.Bikes.FirstOrDefaultAsync(m => m.Id == id);
            if (bike == null)
            {
                return NotFound();
            }
            else 
            {
                Bike = bike;
            }
            return Page();
        }
    }
}
