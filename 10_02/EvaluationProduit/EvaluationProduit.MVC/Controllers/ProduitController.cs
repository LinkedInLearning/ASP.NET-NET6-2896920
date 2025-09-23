using EvaluationProduit.MVC.Filters;
using EvaluationProduit.Domaines.Models;
using EvaluationProduit.Domaines.Services;
using Microsoft.AspNetCore.Mvc;

namespace EvaluationProduit.MVC.Controllers
{
    public class ProduitController : Controller
    {
        private readonly IProduitService _produitService;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ProduitController(IProduitService produitService, IWebHostEnvironment webHostEnvironment)
        {
            _produitService = produitService;
            this.webHostEnvironment = webHostEnvironment;
        }

        //[Route("Produit")]
        //[Route("Produit/Index")]
        //[Route("Produit/{id}")]
        //[ProduitActionFilter]
        [ServiceFilter(typeof(ProduitActionFilter))]
        public IActionResult Index()
        {
            string controller = (string)RouteData.Values["Controller"];

            string id = (string)RouteData.Values["id"];
            ViewBag.Message = "Liste des produits:";

            //return View(ListDesProduits());
            return View(_produitService.ProduitModels);
        }

        //public ContentResult Index()
        //{
        //    //return View(ListDesProduits());
        //    return Content("Bienvenue dans notre cours");
        //}

        //public ViewResult Index()
        //{
        //    return View(_produitService.ProduitModels);
        //}
        //public StatusCodeResult Index()
        //{
        //    return new StatusCodeResult(200);
        //}
        public IActionResult RedirectionVersIndex()
        {
            return RedirectToAction("Index");
        }
        [Route("Produit/Nouveau")]
        public IActionResult Ajouter(ProduitModel model)
        {
            if (ModelState.IsValid)
            {
                var photoModel = ChargerFichier(model.Photo.FichierPhoto);
                model.Photo = photoModel;
                model.Id = _produitService.ProduitModels.Select(p => p.Id).LastOrDefault() + 1;
                _produitService.ProduitModels.Add(model);
                return RedirectToAction("Index", model);
            }

            var errors = ModelState.Select(x => x.Value.Errors)
                .Where(y => y.Count > 0)
                .ToList();

            return View();
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

        //private IList<ProduitModel> ListDesProduits()
        //{
        //    var produitModels = new List<ProduitModel>();
        //    var rnd = new Random();
        //    for (int i = 0; i < 40; i++)
        //    {
        //        var produitModel = new ProduitModel
        //        {
        //            Id = i,
        //            DateCreation = DateTime.Now,
        //            Description = $"C'est la description du produit numéro:{i}",
        //            MoyenneEvaluation = 0,
        //            Nom = $"Produit-:{i}",
        //            Prix = rnd.Next(),
        //            CategorieModel = new CategorieModel
        //            {
        //                Id = i,
        //                Nom = $"Catégorie:{i}"
        //            }
        //        };
        //        produitModels.Add(produitModel);
        //    }
        //    return produitModels;
        //}

        private PhotoModel ChargerFichier(IFormFile photoFile)
        {
            var photoModel = new PhotoModel();
            if (photoFile != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                photoModel.Titre = Guid.NewGuid().ToString() + "_" + photoFile.FileName;
                photoModel.DateCreation = DateTime.Now;
                photoModel.PhotoID = Guid.NewGuid().ToString();
                string filePath = Path.Combine(uploadsFolder, photoModel.Titre);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    photoFile.CopyTo(fileStream);
                }
            }
            return photoModel;
        }
    }
}

