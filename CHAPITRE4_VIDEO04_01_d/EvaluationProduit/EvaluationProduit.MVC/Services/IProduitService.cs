using EvaluationProduit.MVC.Models;

namespace EvaluationProduit.MVC.Services
{
    public interface IProduitService
    {
        IList<ProduitModel> ProduitModels { get; set; }
    }
}
