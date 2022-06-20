using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BikeFitter;
using BikeFitter.Models;

namespace BikeFitter.Pages.Bikes
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
        public Bike Bike { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            PrepareBike();

            if (!ModelState.IsValid || _context.Bikes == null || Bike == null)
            {
                return Page();
            }

            _context.Bikes.Add(Bike);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public List<SelectListItem> GetManufacturers()
        {
            List<SelectListItem> result = new List<SelectListItem>();
            foreach (var c in _context.Manufacturers.ToList())
            {
                result.Add(new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name,
                });
            }
            return result;
        }

        public List<SelectListItem> GetCassettes()
        {
            List<SelectListItem> result = new List<SelectListItem>();
            foreach (var c in _context.Cassettes.ToList())
            {
                result.Add(new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name,
                });
            }
            return result;
        }

        private void PrepareBike()
        {
            if (Bike.Cassette != null)
            {
                Bike.Cassette = _context.Cassettes.Where(c => c.Id == Bike.Cassette.Id).FirstOrDefault();
            }
        }
    }
}
