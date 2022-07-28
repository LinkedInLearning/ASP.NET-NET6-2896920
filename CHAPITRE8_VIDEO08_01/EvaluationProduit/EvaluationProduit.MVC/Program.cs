using EvaluationProduit.MVC.CoreDI;
using EvaluationProduit.MVC.Filters;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureLogging(logging =>
{
    logging.AddJsonConsole(options =>
    {
        options.JsonWriterOptions = new JsonWriterOptions()
        { Indented = true };
    });
});
// Add services to the container.
builder.Services.AddScoped<ProduitActionFilter>();
builder.Services.AjouterProduitServices();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else if (app.Environment.IsStaging() || app.Environment.IsProduction() ||
         app.Environment.IsEnvironment("ExternalProduction"))
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
