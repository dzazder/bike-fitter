using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BikeFitter;
using BikeFitter.Models;

namespace BikeFitter.Pages.Tires
{
    public class DeleteModel : PageModel
    {
        private readonly BikeFitter.BikeFitterContext _context;

        public DeleteModel(BikeFitter.BikeFitterContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Tire Tire { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tires == null)
            {
                return NotFound();
            }

            var tire = await _context.Tires.FirstOrDefaultAsync(m => m.Id == id);

            if (tire == null)
            {
                return NotFound();
            }
            else 
            {
                Tire = tire;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Tires == null)
            {
                return NotFound();
            }
            var tire = await _context.Tires.FindAsync(id);

            if (tire != null)
            {
                Tire = tire;
                _context.Tires.Remove(Tire);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
