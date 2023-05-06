///
/// ObjectChildAssets.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Client.Com.Cumulocity.Client.Model;

/// <summary> 
/// A collection of references to child assets. <br />
/// </summary>
///
public class ObjectChildAssets 
{
	
    /// <summary> 
    /// The total number of child assets. Only present if the value is greater than 0. <br />
    /// </summary>
    ///
    [JsonPropertyName("count")]
    public int? Count { get; set; }
	
    /// <summary> 
    /// An array with the references to child assets. <br />
    /// </summary>
    ///
    [JsonPropertyName("references")]
    public List<ManagedObjectReferenceTuple> References { get; set; } = new List<ManagedObjectReferenceTuple>();
	
    /// <summary> 
    /// Link to this resource's child assets. <br />
    /// </summary>
    ///
    [JsonPropertyName("self")]
    public string? Self { get; set; }
	
    public override string ToString()
    {
        var jsonOptions = new JsonSerializerOptions() 
        { 
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        return JsonSerializer.Serialize(this, jsonOptions);
    }
}