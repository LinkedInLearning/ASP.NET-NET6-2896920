using EvaluationProduit.MVC.CoreDI;
using EvaluationProduit.MVC.Donnees;
using EvaluationProduit.MVC.Filters;
using EvaluationProduit.MVC.Mappeurs;
using EvaluationProduit.MVC.Models;
using EvaluationProduit.MVC.Validation;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ProduitContext>(options => options.UseSqlite("DataSource = produitBD.db"));
builder.Services.AddScoped<ProduitActionFilter>();
builder.Services.AddTransient<IValidator<ProduitModel>, ProduitValidator>();
builder.Services.AddSingleton<IProduitMapper, ProduitMapper>();
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
