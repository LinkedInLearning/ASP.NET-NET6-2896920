using System.Collections.Generic;
using EvaluationProduit.MVC.Donnees;
using EvaluationProduit.MVC.Models;

namespace EvaluationProduit.MVC.Mappeurs
{
    public interface IProduitMapper
    {
        public Produit MapProduitModelEnProduit(ProduitModel model);
        public Categorie MapCategorieModelEnCategorie(CategorieModel model);
        public Photo MapPhotoModelEnPhoto(PhotoModel model);
        public IList<ProduitModel> MapProduitsEnProduitModels(List<Produit> produits);
    }
}
