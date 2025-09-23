using System.ComponentModel.DataAnnotations;

namespace EvaluationProduit.MVC.Donnees
{
    public class Photo
    {
        [Key]
        public string PhotoID { get; set; }
        public string Titre { get; set; }
        public string FichierPhoto { get; set; }
        public string Description { get; set; }
        public DateTime DateCreation { get; set; }
    }
}
