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

namespace BikeFitter.Pages.Forks
{
    public class EditModel : PageModel
    {
        private readonly BikeFitter.BikeFitterContext _context;

        public EditModel(BikeFitter.BikeFitterContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Fork Fork { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Forks == null)
            {
                return NotFound();
            }

            var fork =  await _context.Forks.FirstOrDefaultAsync(m => m.Id == id);
            if (fork == null)
            {
                return NotFound();
            }
            Fork = fork;
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

            _context.Attach(Fork).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ForkExists(Fork.Id))
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

        private bool ForkExists(int id)
        {
          return (_context.Forks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
