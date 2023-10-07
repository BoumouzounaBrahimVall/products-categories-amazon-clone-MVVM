﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MonCatalogueProduit.Models;

namespace MonCatalogueProduit.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly MonCatalogueProduit.Models.CatalogueDbContext _context;

        public EditModel(MonCatalogueProduit.Models.CatalogueDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Categorie Categorie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var categorie =  await _context.Categories.FirstOrDefaultAsync(m => m.CategorieID == id);
            if (categorie == null)
            {
                return NotFound();
            }
            Categorie = categorie;
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
            
            _context.Attach(Categorie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategorieExists(Categorie.CategorieID))
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

        private bool CategorieExists(int id)
        {
          return (_context.Categories?.Any(e => e.CategorieID == id)).GetValueOrDefault();
        }
    }
}
