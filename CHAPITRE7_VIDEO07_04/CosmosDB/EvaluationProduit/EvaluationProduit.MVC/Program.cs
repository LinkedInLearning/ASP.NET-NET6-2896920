using EvaluationProduit.MVC.CoreDI;
using EvaluationProduit.MVC.Donnees;
using EvaluationProduit.MVC.Filters;
using EvaluationProduit.MVC.Mappeurs;
using EvaluationProduit.MVC.Models;
using EvaluationProduit.MVC.Repository;
using EvaluationProduit.MVC.Validation;
using FluentValidation;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddDbContext<ProduitContext>(options => options.UseSqlite("DataSource = produitBD.db"));

//Lire la chaine de connexion à partir du fichier de configuration
//var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ProduitContext>(options => options.UseCosmos("https://produitcosmosdb.documents.azure.com:443/",
                "CosmBzaawWAL9mhmcZRkEGlFQeP8sbMUk6x3kD7eetaGz9UdW5HOcCCPVMGbtKycWOrKNdPyjFGGKbRN50S0MeAkZA==osKey",
                "ProduitBD"));

builder.Services.AddScoped<ProduitActionFilter>();
builder.Services.AddTransient<IValidator<ProduitModel>, ProduitValidator>();
builder.Services.AddSingleton<IProduitMapper, ProduitMapper>();
builder.Services.AddScoped<IProduitRepository, ProduitRepository>();
builder.Services.AjouterProduitServices();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
