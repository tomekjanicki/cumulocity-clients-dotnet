using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Client.Com.Cumulocity.Client.Converter;

internal sealed class ReadOnlyListJsonConvertFactory : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
        => JsonSerializationHelper.CanConvert(typeToConvert, typeof(IReadOnlyList<>));

    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        => JsonSerializationHelper.CreateConverter(JsonSerializationHelper.GetGenericTypeWithOneType(typeToConvert, typeof(ReadOnlyListJsonConverter<>)));

    private sealed class ReadOnlyListJsonConverter<T> : JsonConverter<IReadOnlyList<T>>
    {
        public override bool HandleNull => true;

        public override IReadOnlyList<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => JsonSerializationHelper.ReadArray<T, IReadOnlyList<T>>(ref reader, options, static arg => arg, static () => Array.Empty<T>());

        public override void Write(Utf8JsonWriter writer, IReadOnlyList<T> value, JsonSerializerOptions options)
            => JsonSerializationHelper.WriteEnumerable(writer, value, options);
    }
}