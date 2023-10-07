using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MonCatalogueProduit.Models;

namespace MonCatalogueProduit.Pages.Produits
{
    public class IndexModel : PageModel
    {
        private readonly MonCatalogueProduit.Models .CatalogueDbContext _context;

        public IndexModel(MonCatalogueProduit.Models.CatalogueDbContext context)
        {
            _context = context;
        }

        public IList<Produit> Produit { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Produits != null)
            {
                Produit = await _context.Produits
                .Include(p => p.Categorie).ToListAsync();
            }
        }
    }
}
