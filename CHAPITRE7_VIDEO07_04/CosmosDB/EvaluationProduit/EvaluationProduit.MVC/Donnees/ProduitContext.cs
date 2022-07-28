

using Microsoft.EntityFrameworkCore;

namespace EvaluationProduit.MVC.Donnees
{
    public class ProduitContext : DbContext
    {
        public ProduitContext(DbContextOptions<ProduitContext> options) : base(options)
        {

        }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Photo> Photos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Photo>().ToTable("Photo");
            modelBuilder.Entity<Categorie>().ToTable("Categorie");
            modelBuilder.Entity<Produit>().ToTable("Produit");
        }
    }
}
