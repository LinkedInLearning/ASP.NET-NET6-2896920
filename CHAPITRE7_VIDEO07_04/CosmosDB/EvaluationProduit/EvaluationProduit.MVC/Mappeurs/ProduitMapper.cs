using System;
using System.Collections.Generic;
using EvaluationProduit.MVC.Donnees;
using EvaluationProduit.MVC.Models;

namespace EvaluationProduit.MVC.Mappeurs
{
    public class ProduitMapper : IProduitMapper
    {
        public Produit MapProduitModelEnProduit(ProduitModel model)
        {
            return new Produit
            {
                Categorie = MapCategorieModelEnCategorie(model.CategorieModel),
                Nom = model.Nom,
                Description = model.Description,
                Id = Guid.NewGuid().ToString(),
                DateCreation = DateTime.Now,
                MoyenneEvaluation = model.MoyenneEvaluation,
                Photo = MapPhotoModelEnPhoto(model.Photo)
            };
        }

        public Categorie MapCategorieModelEnCategorie(CategorieModel model)
        {
            return new()
            {
                Id = Guid.NewGuid().ToString(),
                Nom = model.Nom,
                DateCreation = DateTime.Now,
                Description = model.Description
            };
        }

        public Photo MapPhotoModelEnPhoto(PhotoModel model)
        {
            if (string.IsNullOrEmpty(model.Description))
            {
                model.Description = string.Empty;
            }

            return new()
            {
                PhotoID = Guid.NewGuid().ToString(),
                Description = model.Description,
                DateCreation = DateTime.Now,
                FichierPhoto = model.CheminImage,
                Titre = model.FichierPhoto?.FileName
            };
        }

        public ProduitModel MapProduitEnProduitModel(Produit produit)
        {
            return new ProduitModel
            {
                Id = produit.Id,
                DateCreation = produit.DateCreation,
                Description = produit.Description,
                CategorieModel = MapCategorieEnCategorieModel(produit.Categorie),
                Nom = produit.Nom,
                Photo = MapPhotoEnPhotoModel(produit.Photo),
                MoyenneEvaluation = produit.MoyenneEvaluation,
                Prix = produit.Prix
            };
        }

        public IList<ProduitModel> MapProduitsEnProduitModels(List<Produit> produits)
        {
            var produitModels = new List<ProduitModel>();
            produits.ForEach(p =>
            {
                var produitModel = MapProduitEnProduitModel(p);
                produitModels.Add(produitModel);
            });
            return produitModels;
        }
        public PhotoModel MapPhotoEnPhotoModel(Photo photo)
        {
            return new PhotoModel
            {
                DateCreation = photo.DateCreation,
                Description = photo.Description,
                CheminImage = photo.FichierPhoto,
                PhotoID = photo.PhotoID,
                Titre = photo.Titre
            };
        }

        public CategorieModel MapCategorieEnCategorieModel(Categorie categorie)
        {
            return new CategorieModel
            {
                Description = categorie.Description,
                DateCreation = categorie.DateCreation,
                Id = categorie.Id,
                Nom = categorie.Nom
            };
        }
    }
}
