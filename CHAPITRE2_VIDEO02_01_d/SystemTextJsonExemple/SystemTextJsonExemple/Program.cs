using System.Text.Json;
using System.Text.Json.Serialization;

Categorie framework = new()
{
    Name = ".NET 6",
};
Categorie systemTextJson = new()
{
    Name = "System.Text.Json",
    Parent = framework
};
framework.Enfants.Add(systemTextJson);

JsonSerializerOptions options = new()
{
    ReferenceHandler = ReferenceHandler.IgnoreCycles,
    WriteIndented = true
};

string dotnetJson = JsonSerializer.Serialize(framework, options);
Console.WriteLine($"{dotnetJson}");

public class Categorie
{
    public string Name { get; set; }
    public Categorie Parent { get; set; }
    public List<Categorie> Enfants { get; set; } = new();
}