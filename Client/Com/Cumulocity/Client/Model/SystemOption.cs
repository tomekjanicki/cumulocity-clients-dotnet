///
/// SystemOption.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model;

/// <summary> 
/// A tuple storing tenant configuration. <br />
/// </summary>
///
public class SystemOption 
{
	
    /// <summary> 
    /// Name of the system option category. <br />
    /// </summary>
    ///
    [JsonPropertyName("category")]
    public string? Category { get; set; }
	
    /// <summary> 
    /// A unique identifier for this system option. <br />
    /// </summary>
    ///
    [JsonPropertyName("key")]
    public string? Key { get; set; }
	
    /// <summary> 
    /// Value of this system option. <br />
    /// </summary>
    ///
    [JsonPropertyName("value")]
    public string? Value { get; set; }
	
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