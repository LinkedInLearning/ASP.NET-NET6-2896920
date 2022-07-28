using Microsoft.AspNetCore.Identity;

namespace EvaluationProduit.MVC.Authentication
{
    public class Utilisateur :IdentityUser
    {
        public string UserHandle { get; set; }
    }
}
