using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EvaluationProduit.MVC.Validation
{
    public class TousLesLettresValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(Object value)
        {
            if(value!=null) { return ((string)value).All(Char.IsLetter); }

            return true;
        }
    }
}
