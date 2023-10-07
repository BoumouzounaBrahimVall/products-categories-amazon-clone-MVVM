using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MonCatalogueProduit.Models;

namespace MonCatalogueProduit.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly MonCatalogueProduit.Models.CatalogueDbContext _context;

        public CreateModel(MonCatalogueProduit.Models.CatalogueDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Categorie Categorie { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Categories == null || Categorie == null)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        await Console.Out.WriteLineAsync($"Validation Error: {error.ErrorMessage}");
                    }
                }
                return Page();
            }

            _context.Categories.Add(Categorie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
