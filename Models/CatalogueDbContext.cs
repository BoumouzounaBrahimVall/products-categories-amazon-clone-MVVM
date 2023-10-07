using Microsoft.EntityFrameworkCore;

namespace MonCatalogueProduit.Models
{
    public class CatalogueDbContext: DbContext
    {
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Categorie> Categories { get; set; }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-1OOGJDP\\VALL;Database=CAT_DB_8;Trusted_Connection=True;TrustServerCertificate=True");
        }
        */
        public CatalogueDbContext(DbContextOptions<CatalogueDbContext> options)
    : base(options)
        { }
        public CatalogueDbContext()
        {
            
        }
    }
}
