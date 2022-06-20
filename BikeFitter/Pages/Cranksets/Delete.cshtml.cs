using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BikeFitter;
using BikeFitter.Models;

namespace BikeFitter.Pages.Cranksets
{
    public class DeleteModel : PageModel
    {
        private readonly BikeFitter.BikeFitterContext _context;

        public DeleteModel(BikeFitter.BikeFitterContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Crankset Crankset { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cranksets == null)
            {
                return NotFound();
            }

            var crankset = await _context.Cranksets.FirstOrDefaultAsync(m => m.Id == id);

            if (crankset == null)
            {
                return NotFound();
            }
            else 
            {
                Crankset = crankset;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Cranksets == null)
            {
                return NotFound();
            }
            var crankset = await _context.Cranksets.FindAsync(id);

            if (crankset != null)
            {
                Crankset = crankset;
                _context.Cranksets.Remove(Crankset);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
