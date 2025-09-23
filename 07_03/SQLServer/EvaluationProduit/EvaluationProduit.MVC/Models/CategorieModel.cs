using System;

namespace EvaluationProduit.MVC.Models
{
    public record CategorieModel
    {
        public string Id { get; init; }
        public string Nom { get; init; }
        public string Description { get; init; }
        public DateTime DateCreation { get; init; }
    }
}
