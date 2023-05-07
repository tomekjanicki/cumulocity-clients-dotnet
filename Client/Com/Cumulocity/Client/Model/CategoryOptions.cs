///
/// CategoryOptions.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Collections.Generic;
using System.Text.Json.Serialization;
using Client.Com.Cumulocity.Client.Converter;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Model;

[JsonConverter(typeof(CategoryOptionsJsonConverter<CategoryOptions>))]
public class CategoryOptions : IWithCustomFragments
{
	
    /// <summary> 
    /// It is possible to specify an arbitrary number of existing options as a list of key-value pairs, for example, <c>"key1": "value1"</c>, <c>"key2": "value2"</c>. <br />
    /// </summary>
    ///
    [JsonPropertyName("keyValuePairs")]
    public IDictionary<string, object?> CustomFragments { get; set; } = new Dictionary<string, object?>();
		
    [JsonIgnore]
    public object? this[string key]
    {
        get => CustomFragments[key];
        set => CustomFragments[key] = value;
    }
	
    public override string ToString() => JsonSerializerWrapper.SerializeToString(this);

    private static readonly Dictionary<string, System.Type> AdditionalPropertyClasses = new();

    public static bool TryAddProperty(string key, System.Type type)
    {
        return AdditionalPropertyClasses.TryAdd(key, type);
    }

    internal sealed class CategoryOptionsJsonConverter<T> : BaseWithCustomFragmentsJsonConverter<T> where T : CategoryOptions
    {
        public CategoryOptionsJsonConverter() : base(AdditionalPropertyClasses)
        {
        }
    }
}