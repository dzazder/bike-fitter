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
    public class IndexModel : PageModel
    {
        private readonly BikeFitter.BikeFitterContext _context;

        public IndexModel(BikeFitter.BikeFitterContext context)
        {
            _context = context;
        }

        public IList<Fork> Fork { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Forks != null)
            {
                Fork = await _context.Forks.ToListAsync();
            }
        }
    }
}
