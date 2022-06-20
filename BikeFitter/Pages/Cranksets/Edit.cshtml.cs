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

namespace BikeFitter.Pages.Cranksets
{
    public class EditModel : PageModel
    {
        private readonly BikeFitter.BikeFitterContext _context;

        public EditModel(BikeFitter.BikeFitterContext context)
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

            var crankset =  await _context.Cranksets.FirstOrDefaultAsync(m => m.Id == id);
            if (crankset == null)
            {
                return NotFound();
            }
            Crankset = crankset;
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

            _context.Attach(Crankset).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CranksetExists(Crankset.Id))
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

        private bool CranksetExists(int id)
        {
          return (_context.Cranksets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
