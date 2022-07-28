namespace EvaluationProduit.MVC.Models
{
    public class ProduitModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public DateTime DateCreation { get; set; }
        public int MoyenneEvaluation { get; set; }
        public decimal Prix { get; set; }
        public CategorieModel CategorieModel { get; set; }
    }
}
