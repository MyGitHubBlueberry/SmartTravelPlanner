using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;

namespace Travelling;

internal class TravelerData
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("currentLocation")]
    public string CurrentLocation { get; set; } = string.Empty;

    [JsonPropertyName("route")]
    public List<string> Route { get; set; } = new List<string>();
}

public class Traveler : ICloneable 
{
    [JsonProperty] string name;
    [JsonProperty] string currentLocation = "";
    [JsonProperty]
    [Newtonsoft.Json.JsonConverter(typeof(FlatStringListConverter))]
    List<string> route = new List<string>();


    public Traveler(string name) => this.name = name;

    public string this[int index] { get => route[index]; }


    public string GetName() => name;
    public string GetLocation() => currentLocation;
    public void AddCity(string city)
    {
        if (city == null || city == "") 
        {
            throw new Exception("City name must contain characters.");
        }
        route.Add(ToTitle(city));
    }
    public string GetRoute() => string.Join(" -> ",route);
    public override string ToString() =>
        $"Traveler: {name} | Location: {currentLocation} | Route: {GetRoute()}";
    public void ClearRoute() => route.Clear();
    public bool HasCity(string city) => route.Contains(ToTitle(city));
    public void SortRoute() => route.Sort();
    public bool RemoveCity(string city) => route.Remove(ToTitle(city));
    public string GetNextStop() => route.Count != 0 ? route[0] : null;
    public bool PlanRouteTo(string destination, CityGraph map) {
        if (String.IsNullOrEmpty(destination)) {
            Console.WriteLine("No route to find!");
            return false;
        }
        //start from the current location
        string startLocation = currentLocation;
        //if no current location, start form the first city in the currenroute (id 0)
        if (String.IsNullOrEmpty(currentLocation)) {
            if (route.Count == 0 || String.IsNullOrEmpty(route[0])) {
                Console.WriteLine("No route to find!");
                return false;
            }
            startLocation = route[0];
        }

        //if there is no city, print 

        //find the shortest path to the destination 
        //and update the route
        route = map.FindShortestPath(startLocation, destination);
        if (route.Count == 0)
        {
            Console.WriteLine("No route to find!");
            return false;
        }
        return true;
    }

    public object Clone()
    {
        Traveler t = new Traveler(name);
        t.SetLocation(currentLocation);
        t.route = new List<string>(route);
        return t;
    }

    public static bool operator ==(Traveler a, Traveler b)
    {
        if (a is null && b is null)
        {
            return true;
        }

        if (a is null || b is null)
        {
            return false;
        }

        return a.name == b.name && a.currentLocation == b.currentLocation;
    }

    public static bool operator !=(Traveler a, Traveler b) =>
        !(a == b);

    public int GetStopCount() => route.Count;
    public void SetLocation(string location) => currentLocation = ToTitle(location);
    public void SaveToFile(string filePath) {
        File.WriteAllText(filePath, JsonConvert.SerializeObject(this, Formatting.Indented));
    }
    public static Traveler LoadFromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("File not found.", filePath);
        }

        try
        {
            string jsonString = File.ReadAllText(filePath);
            TravelerData? data = System.Text.Json.JsonSerializer.Deserialize<TravelerData>(jsonString);

            if (data == null || data.Name == null)
            {
                throw new FileLoadException("Invalid travel data");
            }

            Traveler traveler = new Traveler(data.Name);
            traveler.SetLocation(data.CurrentLocation ?? string.Empty);

            if (data.Route != null)
            {
                data.Route.ForEach(city => traveler.AddCity(city));
            }

            return traveler;
        }
        catch (JsonException)
        {
            throw new FileLoadException("Invalid travel data");
        }
        catch (Exception ex)
        {
            if (ex is FileLoadException) throw;
            throw new FileLoadException("Invalid travel data");
        }
    }

    static string ToTitle(string s) {
        return string.Join(' ', s
                .Trim()
                .Split(' ', System.StringSplitOptions.RemoveEmptyEntries)
                .Select(word => char.ToUpper(word[0]) + word.Substring(1).ToLower()));
    }

    class FlatStringListConverter : Newtonsoft.Json.JsonConverter<List<string>>
    {
        public override void WriteJson(JsonWriter writer, List<string>? value, JsonSerializer serializer)
        {
            string json = string.Join(", ", JsonConvert.SerializeObject(value, Formatting.None).Split(','));
            writer.WriteRawValue(json);
        }

        public override List<string>? ReadJson(JsonReader reader, Type objectType, List<string>? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            if (reader.TokenType == JsonToken.String)
            {
                string? stringValue = reader.Value as string;

                if (stringValue != null)
                {
                    return JsonConvert.DeserializeObject<List<string>>(stringValue);
                }
            }

            var token = JToken.Load(reader);
            return token.ToObject<List<string>>();
        }
    }
}
