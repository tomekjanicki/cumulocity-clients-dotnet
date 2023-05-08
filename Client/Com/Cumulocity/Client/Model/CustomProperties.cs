///
/// CustomProperties.cs
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

/// <summary> 
/// An object with a list of custom properties. <br />
/// </summary>
///
[JsonConverter(typeof(WithCustomFragmentsJsonConverter<CustomProperties>))]
public class CustomProperties : IWithCustomFragments
{
	
    /// <summary> 
    /// The preferred language to be used in the platform. <br />
    /// </summary>
    ///
    [JsonPropertyName("language")]
    public string? Language { get; set; }
	
    /// <summary> 
    /// It is possible to add an arbitrary number of custom properties as a list of key-value pairs, for example, <c>"property": "value"</c>. <br />
    /// </summary>
    ///
    [JsonIgnore]
    IDictionary<string, object?> IWithCustomFragments.CustomFragments { get; set; } = new Dictionary<string, object?>();
    
    public override string ToString() => JsonSerializerWrapper.SerializeToString(this);
}