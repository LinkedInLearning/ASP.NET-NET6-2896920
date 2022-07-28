using System.ComponentModel.DataAnnotations;

namespace EvaluationProduit.MVC.Models
{
    public class ProduitModel: ModeleBase
    {
        public ProduitModel()
        {
            CategorieModel = new CategorieModel();
        }
        [Range(1, 5, ErrorMessage = "Veuillez introduire une valeur entre 1 et 5")]
        [Display(Name = "Évaluation moyenne")]
        public int MoyenneEvaluation { get; set; }
        //[Display(Name = "Prix")]
        //[Required(ErrorMessage = "Veuillez introduire un prix.")]
        //[DataType(DataType.Currency)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Le prix doit être numérique")]
        public decimal Prix { get; set; }
        public CategorieModel CategorieModel { get; set; }
    }
}
