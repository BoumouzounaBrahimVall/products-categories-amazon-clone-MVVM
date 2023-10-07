using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MonCatalogueProduit.Models;

namespace MonCatalogueProduit.Pages
{
    public class IndexModel : PageModel
    {
        private readonly MonCatalogueProduit.Models.CatalogueDbContext _context;

        public IndexModel(MonCatalogueProduit.Models.CatalogueDbContext context)
        {
            _context = context;
        }

        public IList<Produit> Produit { get;set; } = default!;

        public IList<Categorie> Categorie { get; set; } = default!;

        public async Task OnGetAsync(string searchString)
        {
            if (_context.Produits != null)
            {
                var produits = from p in _context.Produits
                               select p;

                if (!string.IsNullOrEmpty(searchString))
                {
                    produits = produits.Where(p => p.Description.Contains(searchString));
                    Produit = await produits.ToListAsync();
                }
                else Produit = await _context.Produits.Include(p => p.Categorie).ToListAsync();
            }
            if (_context.Categories != null)
            {
                Categorie = await _context.Categories.ToListAsync();
            }
        }
    }
}
