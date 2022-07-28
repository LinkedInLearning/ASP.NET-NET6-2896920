using EvaluationProduit.MVC.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EvaluationProduit.MVC.CoreDI
{
    public static class ProduitCollectionExtensions
    {
        public static IServiceCollection AjouterProduitServices(this IServiceCollection services)
        {
            services.AddSingleton<ICategorieService, CategorieService>();
            services.AddSingleton<IProduitService, ProduitService>();
            return services;
        }
    }
}
