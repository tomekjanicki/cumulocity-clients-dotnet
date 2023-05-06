using System.Text.Json;
using System.Text.Json.Nodes;

namespace Client.Com.Cumulocity.Client.Supplementary;

public static class ObjectExtensions
{
    public static JsonNode? ToJsonNode<T>(this T body)
    {
        var jsonString = JsonSerializer.Serialize(body);
        return JsonSerializer.Deserialize<JsonNode>(jsonString);
    }
}