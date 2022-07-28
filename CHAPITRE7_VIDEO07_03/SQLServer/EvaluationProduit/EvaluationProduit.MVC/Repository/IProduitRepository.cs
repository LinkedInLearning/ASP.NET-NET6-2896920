using System.Collections.Generic;
using EvaluationProduit.MVC.Donnees;

namespace EvaluationProduit.MVC.Repository
{
    public interface IProduitRepository
    {
        IEnumerable<Produit> Produits();
        void InsererProduit(Produit produit);
        void SupprimerProduit(Produit produit);
        void MiseAJourProduit(Produit produit);
    }
}
