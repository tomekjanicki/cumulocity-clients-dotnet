///
/// IdentityApiResource.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model;

public class IdentityApiResource 
{
	
    /// <summary> 
    /// Single external ID, represented by the type and the value of the external ID. <br />
    /// </summary>
    ///
    [JsonPropertyName("externalId")]
    public string? ExternalId { get; set; }
	
    /// <summary> 
    /// Represents a collection of external IDs for a specified global ID. <br />
    /// </summary>
    ///
    [JsonPropertyName("externalIdsOfGlobalId")]
    public string? ExternalIdsOfGlobalId { get; set; }
	
    /// <summary> 
    /// A URL linking to this resource. <br />
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