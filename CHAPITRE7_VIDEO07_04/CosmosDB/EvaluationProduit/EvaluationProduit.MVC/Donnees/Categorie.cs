using System.ComponentModel.DataAnnotations;

namespace EvaluationProduit.MVC.Donnees
{
    public class Categorie
    {
        [Key]
        public string Id { get; init; }
        [Required]
        [StringLength(20)]
        public string Nom { get; init; }
        public string Description { get; init; }
        public DateTime DateCreation { get; init; }
    }
}
