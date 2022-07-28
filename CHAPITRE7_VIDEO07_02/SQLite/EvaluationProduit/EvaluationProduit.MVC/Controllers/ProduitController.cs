using EvaluationProduit.MVC.Donnees;
using EvaluationProduit.MVC.Mappeurs;
using EvaluationProduit.MVC.Models;
using EvaluationProduit.MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace EvaluationProduit.MVC.Controllers
{
    public class ProduitController : Controller
    {
        private readonly IProduitService _produitService;
        private readonly IWebHostEnvironment webHostEnvironment;
        private ProduitContext _produitContext;
        private IProduitMapper _produitMapper;
        public ProduitController(IProduitService produitService, IWebHostEnvironment webHostEnvironment, ProduitContext produitContext, IProduitMapper produitMapper)
        {
            _produitService = produitService;
            this.webHostEnvironment = webHostEnvironment;
            _produitContext = produitContext;
            _produitMapper = produitMapper;
        }
        public IActionResult Index()
        {
            ViewBag.Message = "Liste des produits:";
            ChargerDonnées();
            return View(_produitMapper.MapProduitsEnProduitModels(_produitContext.Produits.ToList()));
        }

        public IActionResult RedirectionVersIndex()
        {
            return RedirectToAction("Index");
        }

        public IActionResult Ajouter(ProduitModel model)
        {
            if (string.IsNullOrEmpty(model.Nom)) { return View(); }

            var photoModel = _produitService.ChargerFichier(model.Photo.FichierPhoto, webHostEnvironment.WebRootPath);

            model.Photo = photoModel;
            var produit = _produitMapper.MapProduitModelEnProduit(model);
            _produitContext.Add(produit);
            _produitContext.SaveChanges();
            var list = _produitContext.Produits.ToList();
            //LINQ
            var rechercheProduit = _produitContext.Produits.FirstOrDefault(p => p.Nom.Equals("Produit-:3"));

            var rechercheProduitResultat = from p in _produitContext.Produits
                                           where p.Nom.Equals("Produit-:3")
                                           select p;

            // LINQ vers Entité
            _produitContext.Entry(rechercheProduit)
                .Reference(c => c.Categorie)
                .Load();

            return RedirectToAction("Index", model);
        }

        public IActionResult Modifier(int id)
        {
            var produitModel = _produitService.ProduitModels.FirstOrDefault(p => p.Id.Equals(id));
            return View(produitModel);
        }

        public IActionResult Details(int id)
        {
            var idProduit = id;
            return View();
        }
        public IActionResult Supprimer(int id)
        {
            var produitModel = _produitService.ProduitModels.FirstOrDefault(p => p.Id.Equals(id));
            return View(produitModel);
        }

        public IActionResult SupprimerProduit(int id)
        {
            var produitModel = _produitService.ProduitModels.FirstOrDefault(p => p.Id.Equals(id));
            _produitService.ProduitModels.Remove(produitModel);
            return RedirectToAction("Index", _produitService.ProduitModels);
        }

        private void ChargerDonnées()
        {
            var rnd = new Random();
            //string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
            //string filePath = Path.Combine(uploadsFolder, "photoModel.Titre");

            for (int i = 0; i < 40; i++)
            {
                var produit = new Produit
                {
                    Id = Guid.NewGuid().ToString(),
                    DateCreation = DateTime.Now,
                    Description = $"C'est la description du produit numéro:{i}",
                    MoyenneEvaluation = 0,
                    Nom = $"Produit-:{i}",
                    Prix = rnd.Next(),
                    Categorie = new Categorie
                    {
                        Id = Guid.NewGuid().ToString(),
                        Nom = $"Catégorie:{i}",
                        Description = $"Description Catégorie:{i}",
                        DateCreation = DateTime.Now
                    },
                    Photo = new Photo
                    {
                        Description = $"Photo produit{i}",
                        Titre = $"Image - {i}",
                        DateCreation = DateTime.Now,
                        PhotoID = Guid.NewGuid().ToString(),
                        FichierPhoto = "fichierPhoto"
                    }
                };
                _produitContext.Produits.Add(produit);
                _produitContext.SaveChanges();
            }


            //    for (var i = 0; i < 40; i++)
            //    {
            //        var categorie = new Categorie
            //        {
            //            Id = i,
            //            Nom = $"Catégorie:{i}",
            //            Description = $"Description Catégorie:{i}",
            //            DateCreation = DateTime.Now
            //        };
            //        _produitContext.Categories.Add(categorie);
            //    }

            //    _produitContext.SaveChanges();
        }
    }
}

