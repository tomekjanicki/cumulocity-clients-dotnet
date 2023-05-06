///
/// BootstrapUser.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Client.Com.Cumulocity.Client.Model;

public sealed class BootstrapUser 
{
	
    /// <summary> 
    /// The bootstrap user tenant username. <br />
    /// </summary>
    ///
    [JsonPropertyName("name")]
    public string? Name { get; set; }
	
    /// <summary> 
    /// The bootstrap user tenant password. <br />
    /// </summary>
    ///
    [JsonPropertyName("password")]
    public string? Password { get; set; }
	
    /// <summary> 
    /// The bootstrap user tenant ID. <br />
    /// </summary>
    ///
    [JsonPropertyName("tenant")]
    public string? Tenant { get; set; }
	
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