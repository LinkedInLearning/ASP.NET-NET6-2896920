using EvaluationProduit.Domaines.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IProduitService, ProduitService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/produits", (IProduitService _produitService) =>
{
    return _produitService.ProduitModels;
})
.WithName("ListDesProduits");

app.MapGet("/produit/{nom}", (IProduitService _produitService, string nom) =>
{
    var produitResultat = _produitService.ProduitModels.FirstOrDefault(p => p.Nom.Equals(nom));
    if (produitResultat == null)
        return Results.NotFound();
    return Results.Ok(produitResultat);
})
.WithName("ProduitParNom");


app.MapPost("/produits", (IProduitService _produitService) => { Results.Ok(); });
app.MapPut("/produit/{id}", (IProduitService _produitService) => { Results.Ok(); });
app.MapDelete("/produit/{id}", (IProduitService _produitService) => { Results.Ok(); });

app.Run();
