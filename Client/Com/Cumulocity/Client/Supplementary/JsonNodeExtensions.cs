using System.Text.Json.Nodes;

namespace Client.Com.Cumulocity.Client.Supplementary;

internal static class JsonNodeExtensions
{
    public static void RemoveFromNode(this JsonNode node, params string[] pathItem)
    {
        if (pathItem.Length > 0)
        {
            var currentNode = node;
            string nodeName = pathItem[0];
            int index = 0;
            while (index < (pathItem.Length - 1))
            {
                currentNode = node[nodeName];
                index++;
                nodeName = pathItem[index];
            }
            if (currentNode?.GetType() == typeof(JsonObject))
            {
                var objectNode = (JsonObject) currentNode;
                objectNode.Remove(nodeName);
            }
        }
    }
}