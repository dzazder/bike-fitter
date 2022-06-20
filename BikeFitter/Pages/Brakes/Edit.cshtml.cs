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

namespace BikeFitter.Pages.Brakes
{
    public class EditModel : PageModel
    {
        private readonly BikeFitter.BikeFitterContext _context;

        public EditModel(BikeFitter.BikeFitterContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Brake Brake { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Brakes == null)
            {
                return NotFound();
            }

            var brake =  await _context.Brakes.FirstOrDefaultAsync(m => m.Id == id);
            if (brake == null)
            {
                return NotFound();
            }
            Brake = brake;
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

            _context.Attach(Brake).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrakeExists(Brake.Id))
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

        private bool BrakeExists(int id)
        {
          return (_context.Brakes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
