///
/// DeviceCredentials.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Client.Com.Cumulocity.Client.Model;

public class DeviceCredentials 
{
	
    /// <summary> 
    /// The external ID of the device. <br />
    /// </summary>
    ///
    [JsonPropertyName("id")]
    public string? Id { get; set; }
	
    /// <summary> 
    /// Password of these device credentials. <br />
    /// </summary>
    ///
    [JsonPropertyName("password")]
    public string? Password { get; set; }
	
    /// <summary> 
    /// A URL linking to this resource. <br />
    /// </summary>
    ///
    [JsonPropertyName("self")]
    public string? Self { get; set; }
	
    /// <summary> 
    /// Tenant ID for these device credentials. <br />
    /// </summary>
    ///
    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }
	
    /// <summary> 
    /// Username of these device credentials. <br />
    /// </summary>
    ///
    [JsonPropertyName("username")]
    public string? Username { get; set; }
	
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