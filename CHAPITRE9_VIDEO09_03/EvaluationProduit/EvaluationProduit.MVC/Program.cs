using EvaluationProduit.MVC.Authentication;
using EvaluationProduit.MVC.CoreDI;
using EvaluationProduit.MVC.Donnees;
using EvaluationProduit.MVC.Filters;
using EvaluationProduit.MVC.Mappeurs;
using EvaluationProduit.MVC.Models;
using EvaluationProduit.MVC.Validation;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Ajouter les services dans le conteneur.
builder.Services.AddDbContext<ProduitContext>(options => options.UseSqlite("DataSource = produitBD.db"));
builder.Services.AddDefaultIdentity<Utilisateur>().AddEntityFrameworkStores<AuthenticationContext>();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireEmail", policy =>
        policy.RequireClaim(ClaimTypes.Email));
});

builder.Services.AddScoped<ProduitActionFilter>();
builder.Services.AddTransient<IValidator<ProduitModel>, ProduitValidator>();
builder.Services.AddSingleton<IProduitMapper, ProduitMapper>();
builder.Services.AjouterProduitServices();
builder.Services.AddControllersWithViews();
builder.Services.AddCors();
var app = builder.Build();

// Configurer le pipeline de requêtes HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<ProduitContext>();
    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
