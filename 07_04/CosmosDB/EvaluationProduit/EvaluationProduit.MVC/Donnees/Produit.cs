using System.ComponentModel.DataAnnotations;

namespace EvaluationProduit.MVC.Donnees
{
    public class Produit
    {
        [Key]
        public string Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public DateTime DateCreation { get; set; }
        public Photo Photo { get; set; }
        public Categorie Categorie { get; set; }
        public int MoyenneEvaluation { get; set; }
        public decimal Prix { get; set; }
    }
}
