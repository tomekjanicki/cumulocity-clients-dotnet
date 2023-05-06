///
/// MeasurementFragmentSeries.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Client.Com.Cumulocity.Client.Model;

public class MeasurementFragmentSeries 
{
	
    /// <summary> 
    /// The unit of the measurement. <br />
    /// </summary>
    ///
    [JsonPropertyName("unit")]
    public string? Unit { get; set; }
	
    /// <summary> 
    /// The name of the measurement. <br />
    /// </summary>
    ///
    [JsonPropertyName("name")]
    public string? Name { get; set; }
	
    /// <summary> 
    /// The type of measurement. <br />
    /// </summary>
    ///
    [JsonPropertyName("type")]
    public string? Type { get; set; }
	
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