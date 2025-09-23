using System.Collections.Generic;
using EvaluationProduit.MVC.Models;

namespace EvaluationProduit.MVC.Services
{
    public interface ICategorieService
    {
        IList<CategorieModel> CategorieModels { get; set; }
        IList<string> CategorieList { get; set; }
    }
}
