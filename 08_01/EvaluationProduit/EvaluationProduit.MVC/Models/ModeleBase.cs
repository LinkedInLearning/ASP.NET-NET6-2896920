using System;
using System.ComponentModel.DataAnnotations;
using EvaluationProduit.MVC.Validation;

namespace EvaluationProduit.MVC.Models
{
    public class ModeleBase
    {
        public ModeleBase()
        {
            Photo = new PhotoModel {DateCreation = DateTime.Now};
        }
        public int Id { get; set; }
        [Display(Name = "Nom")]
        //[Required(ErrorMessage = "Veuillez introduire un nom.")]
        //[TousLesLettresValidation(ErrorMessage = "Seules les lettres sont autorisées.")]
        //[StringLength(10)]
        public string Nom { get; set; }
        //[DataType(DataType.MultilineText)]
        //[StringLength(20)]
        //[MinLength(3)]
        //[MaxLength(20)]
        public string Description { get; set; }
        public PhotoModel Photo { get; set; }
        [Display(Name = "Date de création")]
        //[DisplayFormat(DataFormatString = "{0:dd-mm-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateCreation { get; set; }
    }
}
