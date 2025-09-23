using System;
using System.Collections.Generic;
using System.Linq;
using EvaluationProduit.MVC.Donnees;
using EvaluationProduit.MVC.Models;

namespace EvaluationProduit.MVC.Services
{
    public class CategorieService : ICategorieService
    {
        public IList<CategorieModel> CategorieModels { get; set; }
        public IList<string> CategorieList { get; set; }
        public CategorieService()
        {
            CategorieModels = ListDesCategories();
            CategorieList = ListDesNomCategories();
        }
        private IList<CategorieModel> ListDesCategories()
        {
            var categorieModels = new List<CategorieModel>();
            for (int i = 0; i < 40; i++)
            {
                var categoryModel = new CategorieModel
                {
                    Id = i.ToString(),
                    Nom = $"Catégorie:{i}",
                    Description = $"Description Catégorie:{i}",
                    DateCreation = DateTime.Now
                };
                categorieModels.Add(categoryModel);
            }

            return categorieModels;
        }

        private IList<string> ListDesNomCategories()
        {
            var categorieModels = CategorieModels?.Select(c => c.Nom).ToList();
            return categorieModels;
        }
    }
}
