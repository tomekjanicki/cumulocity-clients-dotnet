using System.IO;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Client.Com.Cumulocity.Client.Converter;

namespace Client.Com.Cumulocity.Client.Supplementary;

internal static class JsonSerializerWrapper
{
    private static readonly JsonSerializerOptions ToStringJsonSerializerOptions = new()
    {
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        Converters = { new ReadOnlyListJsonConvertFactory() }
    };

    private static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        Converters = { new ReadOnlyListJsonConvertFactory() }
    };

    public static string SerializeToString<T>(T obj)
    {
        return JsonSerializer.Serialize(obj, ToStringJsonSerializerOptions);
    }

    public static ValueTask<T?> DeserializeAsync<T>(Stream utf8Stream, CancellationToken cancellationToken = default)
    {
        return JsonSerializer.DeserializeAsync<T>(utf8Stream, JsonSerializerOptions, cancellationToken: cancellationToken);
    }

    public static string Serialize<T>(T obj)
    {
        return JsonSerializer.Serialize(obj, JsonSerializerOptions);
    }

    public static T? Deserialize<T>(string jsonString)
    {
        return JsonSerializer.Deserialize<T>(jsonString, JsonSerializerOptions);
    }

    public static byte[] SerializeToUtf8Bytes<T>(T obj)
    {
        return JsonSerializer.SerializeToUtf8Bytes(obj, JsonSerializerOptions);
    }
}