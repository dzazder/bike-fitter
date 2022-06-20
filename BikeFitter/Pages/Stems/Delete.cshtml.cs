using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BikeFitter;
using BikeFitter.Models;

namespace BikeFitter.Pages.Stems
{
    public class DeleteModel : PageModel
    {
        private readonly BikeFitter.BikeFitterContext _context;

        public DeleteModel(BikeFitter.BikeFitterContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Stem Stem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Stems == null)
            {
                return NotFound();
            }

            var stem = await _context.Stems.FirstOrDefaultAsync(m => m.Id == id);

            if (stem == null)
            {
                return NotFound();
            }
            else 
            {
                Stem = stem;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Stems == null)
            {
                return NotFound();
            }
            var stem = await _context.Stems.FindAsync(id);

            if (stem != null)
            {
                Stem = stem;
                _context.Stems.Remove(Stem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
