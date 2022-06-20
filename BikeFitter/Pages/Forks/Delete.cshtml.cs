using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BikeFitter;
using BikeFitter.Models;

namespace BikeFitter.Pages.Forks
{
    public class DeleteModel : PageModel
    {
        private readonly BikeFitter.BikeFitterContext _context;

        public DeleteModel(BikeFitter.BikeFitterContext context)
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

            var fork = await _context.Forks.FirstOrDefaultAsync(m => m.Id == id);

            if (fork == null)
            {
                return NotFound();
            }
            else 
            {
                Fork = fork;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Forks == null)
            {
                return NotFound();
            }
            var fork = await _context.Forks.FindAsync(id);

            if (fork != null)
            {
                Fork = fork;
                _context.Forks.Remove(Fork);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
