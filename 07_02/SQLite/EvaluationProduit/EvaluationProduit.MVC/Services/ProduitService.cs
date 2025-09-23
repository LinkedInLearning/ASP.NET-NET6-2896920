using System;
using System.Collections.Generic;
using System.IO;
using EvaluationProduit.MVC.Models;
using Microsoft.AspNetCore.Http;

namespace EvaluationProduit.MVC.Services
{
    public class ProduitService: IProduitService
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
                    Id = i.ToString(),
                    DateCreation = DateTime.Now,
                    Description = $"C'est la description du produit numéro:{i}",
                    MoyenneEvaluation = 0,
                    Nom = $"Produit-:{i}",
                    Prix = rnd.Next(),
                    CategorieModel = new CategorieModel
                    {
                        Id = i.ToString(),
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

        public PhotoModel ChargerFichier(IFormFile photoFile, string webRootPath)
        {
            var photoModel = new PhotoModel();
            if (photoFile != null)
            {
                string uploadsFolder = Path.Combine(webRootPath, "images");
                photoModel.Titre = Guid.NewGuid().ToString() + "_" + photoFile.FileName;
                photoModel.DateCreation = DateTime.Now;
                photoModel.PhotoID = Guid.NewGuid().ToString();
                string filePath = Path.Combine(uploadsFolder, photoModel.Titre);
                photoModel.CheminImage = filePath;
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    photoFile.CopyTo(fileStream);
                }
            }
            return photoModel;
        }
    }
}
