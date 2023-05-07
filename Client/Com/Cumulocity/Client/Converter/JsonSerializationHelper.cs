using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Client.Com.Cumulocity.Client.Converter;

internal static class JsonSerializationHelper
{
    public static bool CanConvert(Type typeToConvert, Type converterOpenType) => typeToConvert.IsGenericType && typeToConvert.GetGenericTypeDefinition() == converterOpenType;

    public static Type GetGenericTypeWithOneType(Type typeToConvert, Type converterOpenType)
    {
        var types = typeToConvert.GetGenericArguments();

        return converterOpenType.MakeGenericType(types[0]);
    }

    public static JsonConverter CreateConverter(Type type) =>
        (JsonConverter)Activator.CreateInstance(
            type,
            BindingFlags.Instance | BindingFlags.Public,
            binder: null,
            args: Array.Empty<object>(),
            culture: null)!;

    public static TReturn ReadArray<TElement, TReturn>(ref Utf8JsonReader reader, JsonSerializerOptions options, Func<TElement[], TReturn> constructorFunc,
        Func<TReturn> emptyFunc) =>
        Read(ref reader, options, constructorFunc, emptyFunc);

    private static TReturn Read<T, TReturn>(ref Utf8JsonReader reader, JsonSerializerOptions options, Func<T, TReturn> constructorFunc, Func<TReturn> emptyFunc)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return emptyFunc();
        }
        var valueType = typeof(T);
        var valueConverter = (JsonConverter<T>)options.GetConverter(valueType);
        var value = valueConverter.Read(ref reader, valueType, options)!;

        return constructorFunc(value);
    }

    public static void WriteEnumerable<T>(Utf8JsonWriter writer, IEnumerable<T> value, JsonSerializerOptions options)
        => Write(writer, value, options);

    private static void Write<T>(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        var valueConverter = (JsonConverter<T?>)options.GetConverter(typeof(T));
        valueConverter.Write(writer, value, options);
    }
}