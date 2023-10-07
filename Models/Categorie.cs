using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonCatalogueProduit.Models
{
    [Table("CATEGORIES")]
    public class Categorie
    {
        [Key]
        public int CategorieID { get; set; }
        [Required]
        public string NomCategorie { get; set; }
        public virtual ICollection<Produit>? Produits { get; set; }
    }
}
