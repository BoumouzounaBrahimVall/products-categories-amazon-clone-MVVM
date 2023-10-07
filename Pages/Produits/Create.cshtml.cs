using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MonCatalogueProduit.Models;
using System.ComponentModel.DataAnnotations;

namespace MonCatalogueProduit.Pages.Produits
{
    public class CreateModel : PageModel
    {
        private readonly MonCatalogueProduit.Models.CatalogueDbContext _context;
        private readonly IWebHostEnvironment _henv;

        public CreateModel(MonCatalogueProduit.Models.CatalogueDbContext context, IWebHostEnvironment henv)
        {
            _context = context;
            _henv = henv;
        }

        public IActionResult OnGet()
        {
            ViewData["CategorieID"] = new SelectList(_context.Categories, "CategorieID", "NomCategorie");
            return Page();
        }

        [BindProperty]
        public Produit Produit { get; set; } = default!;
        [BindProperty]
      //  [Required(ErrorMessage = "Please select an image.")]
       // [Display(Name = "Product Image")]
        public IFormFile ImageFile { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            /*
            if (!ModelState.IsValid || _context.Produits == null || Produit == null)
            {                
                return Page();
            }*/

            //   _henv.ContentRootPath

            // Save the image to a directory on the server
            var fileName= Path.GetFileName(ImageFile.FileName);
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", fileName);


            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
               await ImageFile.CopyToAsync(fileStream);
            }
            // Update the product's image path in the database
            Produit.ImagePath = "images/" + fileName;
            await Console.Out.WriteLineAsync("here");
            _context.Produits.Add(Produit);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
