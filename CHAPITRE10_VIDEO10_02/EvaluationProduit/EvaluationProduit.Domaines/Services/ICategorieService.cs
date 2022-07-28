using EvaluationProduit.Domaines.Models;

namespace EvaluationProduit.Domaines.Services
{
    public interface ICategorieService
    {
        IList<CategorieModel> CategorieModels { get; set; }
        IList<string> CategorieList { get; set; }
    }
}
