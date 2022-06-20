using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BikeFitter;
using BikeFitter.Models;

namespace BikeFitter.Pages.Derailleurs
{
    public class DeleteModel : PageModel
    {
        private readonly BikeFitter.BikeFitterContext _context;

        public DeleteModel(BikeFitter.BikeFitterContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Derailleur Derailleur { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Derailleurs == null)
            {
                return NotFound();
            }

            var derailleur = await _context.Derailleurs.FirstOrDefaultAsync(m => m.Id == id);

            if (derailleur == null)
            {
                return NotFound();
            }
            else 
            {
                Derailleur = derailleur;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Derailleurs == null)
            {
                return NotFound();
            }
            var derailleur = await _context.Derailleurs.FindAsync(id);

            if (derailleur != null)
            {
                Derailleur = derailleur;
                _context.Derailleurs.Remove(Derailleur);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
