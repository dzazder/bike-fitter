using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BikeFitter;
using BikeFitter.Models;

namespace BikeFitter.Pages.Shifters
{
    public class DetailsModel : PageModel
    {
        private readonly BikeFitter.BikeFitterContext _context;

        public DetailsModel(BikeFitter.BikeFitterContext context)
        {
            _context = context;
        }

      public Shifter Shifter { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Shifters == null)
            {
                return NotFound();
            }

            var shifter = await _context.Shifters.FirstOrDefaultAsync(m => m.Id == id);
            if (shifter == null)
            {
                return NotFound();
            }
            else 
            {
                Shifter = shifter;
            }
            return Page();
        }
    }
}
