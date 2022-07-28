using EvaluationProduit.MVC.Models;

namespace EvaluationProduit.MVC.Services
{
    public interface IProduitService
    {
        IList<ProduitModel> ProduitModels { get; set; }
        public float RecupererlaMoyenneEvaluation(int evaluation1, int evaluation2);
    }
}
