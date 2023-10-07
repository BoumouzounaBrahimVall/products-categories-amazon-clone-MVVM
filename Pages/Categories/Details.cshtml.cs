using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MonCatalogueProduit.Models;

namespace MonCatalogueProduit.Pages.Categories
{
    public class DetailsModel : PageModel
    {
        private readonly MonCatalogueProduit.Models.CatalogueDbContext _context;

        public DetailsModel(MonCatalogueProduit.Models.CatalogueDbContext context)
        {
            _context = context;
        }

      public Categorie Categorie { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var categorie = await _context.Categories.FirstOrDefaultAsync(m => m.CategorieID == id);
            if (categorie == null)
            {
                return NotFound();
            }
            else 
            {
                Categorie = categorie;
            }
            return Page();
        }
    }
}
