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
    public class DeleteModel : PageModel
    {
        private readonly BikeFitter.BikeFitterContext _context;

        public DeleteModel(BikeFitter.BikeFitterContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Bikes == null)
            {
                return NotFound();
            }
            var bike = await _context.Bikes.FindAsync(id);

            if (bike != null)
            {
                Bike = bike;
                _context.Bikes.Remove(Bike);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
