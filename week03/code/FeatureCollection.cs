using System.Text.Json.Serialization;
public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary

    [JsonPropertyName("features")] // with this we explicitly map the JSON field "features" to our C# property Features
    public List<Feature> Features { get; set; }
}

public class Feature
{
    [JsonPropertyName("properties")] 
    public Dictionary<string, object> Properties { get; set; } // with this we explicitly map the JSON field "properties" to our C# property Properties
}

