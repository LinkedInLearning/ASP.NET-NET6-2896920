using EvaluationProduit.MVC.Exceptions;
using EvaluationProduit.MVC.Models;

namespace EvaluationProduit.MVC.Services
{
    public class ProduitService : IProduitService
    {
        public IList<ProduitModel> ProduitModels { get; set; }
        public float RecupererlaMoyenneEvaluation(int evaluation1, int evaluation2)
        {
            if (evaluation1 < 1)
                throw new MoyenneEvaluationInvalideExeption();

            return (evaluation1 + evaluation2) / 2;
        }

        public ProduitService()
        {
            try
            {
                ProduitModels = ListDesProduits();
            }
            catch (ArgumentNullException ex)
            {
                //Gérer l'exception
            }
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
                    },
                    Photo = new PhotoModel
                    {
                        Description = $"Photo produit{i}",
                        Titre = $"Image - {i}",
                        DateCreation = DateTime.Now
                    }
                };
                produitModels.Add(produitModel);
            }
            return produitModels;
        }
    }
}
