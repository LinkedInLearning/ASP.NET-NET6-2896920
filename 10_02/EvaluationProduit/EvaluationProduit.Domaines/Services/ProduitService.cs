using EvaluationProduit.Domaines.Models;

namespace EvaluationProduit.Domaines.Services
{
    public class ProduitService : IProduitService
    {
        public IList<ProduitModel> ProduitModels { get; set; }

        public ProduitService()
        {
            ProduitModels = ListDesProduits();
        }
        private IList<ProduitModel> ListDesProduits()
        {
            var produitModels = new List<ProduitModel>();
            var rnd = new Random();
            for (int i = 0; i < 40; i++)
            {
                var produitModel = new ProduitModel
                {
                    Id = i,
                    DateCreation = DateTime.Now,
                    Description = $"C'est la description du produit numéro:{i}",
                    MoyenneEvaluation = 0,
                    Nom = $"Produit-:{i}",
                    Prix = rnd.Next(),
                    CategorieModel = new CategorieModel
                    {
                        Id = i,
                        Nom = $"Catégorie:{i}",
                        Description = $"Description Catégorie:{i}",
                        DateCreation = DateTime.Now
                    }
                };
                produitModels.Add(produitModel);
            }
            return produitModels;
        }
    }
}
