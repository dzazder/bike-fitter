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
    public class DetailsModel : PageModel
    {
        private readonly BikeFitter.BikeFitterContext _context;

        public DetailsModel(BikeFitter.BikeFitterContext context)
        {
            _context = context;
        }

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
    }
}
