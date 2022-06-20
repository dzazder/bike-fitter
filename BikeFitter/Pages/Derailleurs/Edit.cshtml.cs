using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BikeFitter;
using BikeFitter.Models;

namespace BikeFitter.Pages.Derailleurs
{
    public class EditModel : PageModel
    {
        private readonly BikeFitter.BikeFitterContext _context;

        public EditModel(BikeFitter.BikeFitterContext context)
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

            var derailleur =  await _context.Derailleurs.FirstOrDefaultAsync(m => m.Id == id);
            if (derailleur == null)
            {
                return NotFound();
            }
            Derailleur = derailleur;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Derailleur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DerailleurExists(Derailleur.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DerailleurExists(int id)
        {
          return (_context.Derailleurs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
