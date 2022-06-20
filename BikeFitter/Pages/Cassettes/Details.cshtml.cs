using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BikeFitter;
using BikeFitter.Models;

namespace BikeFitter.Pages.Cassettes
{
    public class DetailsModel : PageModel
    {
        private readonly BikeFitter.BikeFitterContext _context;

        public DetailsModel(BikeFitter.BikeFitterContext context)
        {
            _context = context;
        }

      public Cassette Cassette { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cassettes == null)
            {
                return NotFound();
            }

            var cassette = await _context.Cassettes.FirstOrDefaultAsync(m => m.Id == id);
            if (cassette == null)
            {
                return NotFound();
            }
            else 
            {
                Cassette = cassette;
            }
            return Page();
        }
    }
}
