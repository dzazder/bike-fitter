using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BikeFitter;
using BikeFitter.Models;

namespace BikeFitter.Pages.Rims
{
    public class DeleteModel : PageModel
    {
        private readonly BikeFitter.BikeFitterContext _context;

        public DeleteModel(BikeFitter.BikeFitterContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Rim Rim { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Rims == null)
            {
                return NotFound();
            }

            var rim = await _context.Rims.FirstOrDefaultAsync(m => m.Id == id);

            if (rim == null)
            {
                return NotFound();
            }
            else 
            {
                Rim = rim;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Rims == null)
            {
                return NotFound();
            }
            var rim = await _context.Rims.FindAsync(id);

            if (rim != null)
            {
                Rim = rim;
                _context.Rims.Remove(Rim);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
