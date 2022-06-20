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

namespace BikeFitter.Pages.Rims
{
    public class EditModel : PageModel
    {
        private readonly BikeFitter.BikeFitterContext _context;

        public EditModel(BikeFitter.BikeFitterContext context)
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

            var rim =  await _context.Rims.FirstOrDefaultAsync(m => m.Id == id);
            if (rim == null)
            {
                return NotFound();
            }
            Rim = rim;
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

            _context.Attach(Rim).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RimExists(Rim.Id))
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

        private bool RimExists(int id)
        {
          return (_context.Rims?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
