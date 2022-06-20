using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BikeFitter;
using BikeFitter.Models;

namespace BikeFitter.Pages.Brakes
{
    public class DetailsModel : PageModel
    {
        private readonly BikeFitter.BikeFitterContext _context;

        public DetailsModel(BikeFitter.BikeFitterContext context)
        {
            _context = context;
        }

      public Brake Brake { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Brakes == null)
            {
                return NotFound();
            }

            var brake = await _context.Brakes.FirstOrDefaultAsync(m => m.Id == id);
            if (brake == null)
            {
                return NotFound();
            }
            else 
            {
                Brake = brake;
            }
            return Page();
        }
    }
}
