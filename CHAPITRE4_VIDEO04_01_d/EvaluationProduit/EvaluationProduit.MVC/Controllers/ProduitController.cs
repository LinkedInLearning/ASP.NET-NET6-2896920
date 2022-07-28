using EvaluationProduit.MVC.Models;
using EvaluationProduit.MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace EvaluationProduit.MVC.Controllers
{
    public class ProduitController : Controller
    {
        private readonly IProduitService _produitService;

        public ProduitController(IProduitService produitService)
        {
            _produitService = produitService;
        }
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
        public IActionResult Ajouter()
        {
            return View();
        }

        public IActionResult Modifier(int id)
        {
            var idProduit = id;
            return View();
        }

        public IActionResult Details(int id)
        {
            var idProduit = id;
            return View();
        }

        public IActionResult Supprimer()
        {
            return View();
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
                        CategorieId = i,
                        NomCategorie = $"Catégorie:{i}"
                    }
                };
                produitModels.Add(produitModel);
            }
            return produitModels;
        }
    }
}
