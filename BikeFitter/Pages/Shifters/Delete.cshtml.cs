using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BikeFitter;
using BikeFitter.Models;

namespace BikeFitter.Pages.Shifters
{
    public class DeleteModel : PageModel
    {
        private readonly BikeFitter.BikeFitterContext _context;

        public DeleteModel(BikeFitter.BikeFitterContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Shifter Shifter { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Shifters == null)
            {
                return NotFound();
            }

            var shifter = await _context.Shifters.FirstOrDefaultAsync(m => m.Id == id);

            if (shifter == null)
            {
                return NotFound();
            }
            else 
            {
                Shifter = shifter;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Shifters == null)
            {
                return NotFound();
            }
            var shifter = await _context.Shifters.FindAsync(id);

            if (shifter != null)
            {
                Shifter = shifter;
                _context.Shifters.Remove(Shifter);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
