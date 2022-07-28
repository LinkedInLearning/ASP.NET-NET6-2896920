// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using System.Text.Json.Nodes;

    string jsonString =
@"{
  ""Date"": ""2019-08-01T00:00:00"",
  ""Temperature"": 25,
  ""Summary"": ""Hot"",
  ""DatesAvailable"": [
    ""2019-08-01T00:00:00"",
    ""2019-08-02T00:00:00""
  ],
  ""TemperatureRanges"": {
      ""Cold"": {
          ""High"": 20,
          ""Low"": -10
      },
      ""Hot"": {
          ""High"": 60,
          ""Low"": 20
      }
  }
}
";
var writerOptions = new JsonWriterOptions
{
    Indented = true
};

var documentOptions = new JsonDocumentOptions
{
    CommentHandling = JsonCommentHandling.Skip
};
string outputFileName = ".\\outputFileName.txt";
using FileStream fs = File.Create(outputFileName);
using var writer = new Utf8JsonWriter(fs, options: writerOptions);
using JsonDocument document = JsonDocument.Parse(jsonString, documentOptions);

JsonElement root = document.RootElement;

if (root.ValueKind == JsonValueKind.Object)
{
    writer.WriteStartObject();
}
else
{
    return;
}

foreach (JsonProperty property in root.EnumerateObject())
{
    property.WriteTo(writer);
}

writer.WriteEndObject();

writer.Flush();
//// Parser le fichier JSON.
//JsonNode forecastNode = JsonNode.Parse(jsonString)!;

//// Récupérer une seule valeur
//int hotHigh = forecastNode["TemperatureRanges"]!["Hot"]!["High"]!.GetValue<int>();
//Console.WriteLine($"Hot.High={hotHigh}");
//// sortie:
////Hot.High=60

//// Obtenez une sous-section et désérialisez-la dans un type personnalisé.
//JsonObject temperatureRangesObject = forecastNode!["TemperatureRanges"]!.AsObject();
//using var stream = new MemoryStream();
//using var writer = new Utf8JsonWriter(stream);
//temperatureRangesObject.WriteTo(writer);
//writer.Flush();
//TemperatureRanges? temperatureRanges =
//    JsonSerializer.Deserialize<TemperatureRanges>(stream.ToArray());
//Console.WriteLine($"Cold.Low={temperatureRanges!["Cold"].Low}, Hot.High={temperatureRanges["Hot"].High}");
//// sortie:
////Cold.Low=-10, Hot.High=60

//// Obtenez une sous-section et désérialisez-la dans un tableau.
//JsonArray datesAvailable = forecastNode!["DatesAvailable"]!.AsArray()!;
//Console.WriteLine($"DatesAvailable[0]={datesAvailable[0]}");
//// Sortie:
////DatesAvailable[0]=8/1/2019 12:00:00 AM

//public class TemperatureRanges : Dictionary<string, HighLowTemps>
//{
//}

//public class HighLowTemps
//{
//    public int High { get; set; }
//    public int Low { get; set; }
//}

//// Créer JsonNode DOM à partir de JSON string.
//JsonNode forecastNode = JsonNode.Parse(jsonString)!;

//// Écrire en JSON à partir de JsonNode
//var options = new JsonSerializerOptions { WriteIndented = true };
//Console.WriteLine(forecastNode!.ToJsonString(options));

//// Récupérer la valeur partir de JsonNode.
//JsonNode temperatureNode = forecastNode!["Temperature"]!;
//Console.WriteLine($"Type={temperatureNode.GetType()}");
//Console.WriteLine($"JSON={temperatureNode.ToJsonString()}");

//// Obtenir une valeur typée à partir de JsonNode.
//int temperatureInt = (int)forecastNode!["Temperature"]!;
//Console.WriteLine($"Value={temperatureInt}");

//// Obtenir une valeur typée à partir de JsonNode en utilisant GetValue<T>.
//temperatureInt = forecastNode!["Temperature"]!.GetValue<int>();
//Console.WriteLine($"TemperatureInt={temperatureInt}");
////output:

//// Récupréer un objet JSON à partir de JsonNode.
//JsonNode temperatureRanges = forecastNode!["TemperatureRanges"]!;
//Console.WriteLine($"Type={temperatureRanges.GetType()}");
//Console.WriteLine($"JSON={temperatureRanges.ToJsonString()}");


//// Récuprer un taleau JSON à partir de JsonNode.
//JsonNode datesAvailable = forecastNode!["DatesAvailable"]!;
//Console.WriteLine($"Type={datesAvailable.GetType()}");
//Console.WriteLine($"JSON={datesAvailable.ToJsonString()}");

//// Obtenir une valeur d'élément de tableau à parti de JsonArray.
//JsonNode firstDateAvailable = datesAvailable[0]!;
//Console.WriteLine($"Type={firstDateAvailable.GetType()}");
//Console.WriteLine($"JSON={firstDateAvailable.ToJsonString()}");

//// Obtenir une valeur typée en enchaînant les références.
//int coldHighTemperature = (int)forecastNode["TemperatureRanges"]!["Cold"]!["High"]!;
//Console.WriteLine($"TemperatureRanges.Cold.High={coldHighTemperature}");

//// Parser un tableau JSON
//var datesNode = JsonNode.Parse(@"[""2019-08-01T00:00:00"",""2019-08-02T00:00:00""]");
//JsonNode firstDate = datesNode![0]!.GetValue<DateTime>();
//Console.WriteLine($"firstDate={firstDate}");
