using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BikeFitter;
using BikeFitter.Models;

namespace BikeFitter.Pages.Manufacturers
{
    public class IndexModel : PageModel
    {
        private readonly BikeFitter.BikeFitterContext _context;

        public IndexModel(BikeFitter.BikeFitterContext context)
        {
            _context = context;
        }

        public IList<Manufacturer> Manufacturer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Manufacturers != null)
            {
                Manufacturer = await _context.Manufacturers.ToListAsync();
            }
        }
    }
}
