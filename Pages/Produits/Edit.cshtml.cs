using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MonCatalogueProduit.Models;

namespace MonCatalogueProduit.Pages.Produits
{
    public class EditModel : PageModel
    {
        private readonly MonCatalogueProduit.Models.CatalogueDbContext _context;

        public EditModel(MonCatalogueProduit.Models.CatalogueDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Produit Produit { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Produits == null)
            {
                return NotFound();
            }

            var produit =  await _context.Produits.FirstOrDefaultAsync(m => m.ProduitID == id);
            if (produit == null)
            {
                return NotFound();
            }
            Produit = produit;
           ViewData["CategorieID"] = new SelectList(_context.Categories, "CategorieID", "NomCategorie");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            

           if (!ModelState.IsValid)
           {
               return Page();
           }
           

            _context.Attach(Produit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProduitExists(Produit.ProduitID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProduitExists(int id)
        {
          return (_context.Produits?.Any(e => e.ProduitID == id)).GetValueOrDefault();
        }
    }
}
