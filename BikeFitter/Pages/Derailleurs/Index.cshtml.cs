﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BikeFitter;
using BikeFitter.Models;

namespace BikeFitter.Pages.Derailleurs
{
    public class IndexModel : PageModel
    {
        private readonly BikeFitter.BikeFitterContext _context;

        public IndexModel(BikeFitter.BikeFitterContext context)
        {
            _context = context;
        }

        public IList<Derailleur> Derailleur { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Derailleurs != null)
            {
                Derailleur = await _context.Derailleurs.ToListAsync();
            }
        }
    }
}
