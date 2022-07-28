using EvaluationProduit.MVC.Models;
using FluentValidation;

namespace EvaluationProduit.MVC.Validation
{
    public class ProduitValidator: AbstractValidator<ProduitModel>
    {
        public ProduitValidator()
        {
            RuleFor(p => p.Nom).NotNull().WithMessage("[Validation Nom] Veuillez introduire le nom de votre produit!");
            RuleFor(p => p.MoyenneEvaluation).InclusiveBetween(1, 5).WithMessage("[Validation Moyenne] Veuillez introduire un chiffre entre 1 et 5");
        }
    }
}
