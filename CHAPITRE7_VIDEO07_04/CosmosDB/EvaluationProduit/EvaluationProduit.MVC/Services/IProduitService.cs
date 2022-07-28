using System.Collections.Generic;
using EvaluationProduit.MVC.Models;
using Microsoft.AspNetCore.Http;

namespace EvaluationProduit.MVC.Services
{
    public interface IProduitService
    {
        IList<ProduitModel> ProduitModels { get; set; }
        public PhotoModel ChargerFichier(IFormFile photoFile, string webRootPath);
    }
}
