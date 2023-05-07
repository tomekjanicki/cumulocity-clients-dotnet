using System.Text.Json.Nodes;

namespace Client.Com.Cumulocity.Client.Supplementary;

internal static class ObjectExtensions
{
    public static JsonNode? ToJsonNode<T>(this T body)
    {
        var jsonString = JsonSerializerWrapper.Serialize(body);
        return JsonSerializerWrapper.Deserialize<JsonNode>(jsonString);
    }
}