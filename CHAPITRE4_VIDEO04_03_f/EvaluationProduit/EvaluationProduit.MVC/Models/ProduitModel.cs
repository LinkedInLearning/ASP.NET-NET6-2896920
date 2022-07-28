namespace EvaluationProduit.MVC.Models
{
    public class ProduitModel : ModeleBase
    {
        public int MoyenneEvaluation { get; set; }
        public decimal Prix { get; set; }
        public CategorieModel CategorieModel { get; set; }

    }
}
