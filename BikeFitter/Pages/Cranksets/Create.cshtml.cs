﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BikeFitter;
using BikeFitter.Models;

namespace BikeFitter.Pages.Cranksets
{
    public class CreateModel : PageModel
    {
        private readonly BikeFitter.BikeFitterContext _context;

        public CreateModel(BikeFitter.BikeFitterContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Crankset Crankset { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Cranksets == null || Crankset == null)
            {
                return Page();
            }

            _context.Cranksets.Add(Crankset);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
