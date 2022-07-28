using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace EvaluationProduit.MVC.Models
{
    public class PhotoModel
    {
        public string PhotoID { get; set; }
        public string Titre { get; set; }
        //[Required(ErrorMessage = "Veuillez ajouter une photo.")]
        public IFormFile FichierPhoto { get; set; }
        public string Description { get; set; }
        public DateTime DateCreation { get; set; }
    }
}
