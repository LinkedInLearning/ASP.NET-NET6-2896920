using System;
using System.Collections.Generic;
using EvaluationProduit.MVC.Donnees;

namespace EvaluationProduit.MVC.Repository
{
    public class ProduitRepository: IProduitRepository
    {
        private ProduitContext _produitContext;

        public ProduitRepository(ProduitContext produitContext)
        {
            _produitContext = produitContext;
        }

        public IEnumerable<Produit> Produits()
        {
            return _produitContext.Produits;
        }

        public void InsererProduit(Produit produit)
        {
            _produitContext.Produits.Add(produit);
            _produitContext.SaveChanges();
        }

        public void SupprimerProduit(Produit produit)
        {
            _produitContext.Produits.Remove(produit);
            _produitContext.SaveChanges();
        }

        public void MiseAJourProduit(Produit produit)
        {
            throw new NotImplementedException();
        }
    }
}
