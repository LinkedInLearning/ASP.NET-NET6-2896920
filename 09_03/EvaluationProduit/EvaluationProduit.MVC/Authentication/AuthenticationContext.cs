using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EvaluationProduit.MVC.Authentication
{
    public class AuthenticationContext : IdentityDbContext<Utilisateur>
    {
        public AuthenticationContext(DbContextOptions<AuthenticationContext> options) :
            base(options)
        {
        }
    }
}