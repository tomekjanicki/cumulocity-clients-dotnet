///
/// UsageStatisticsResources.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Client.Com.Cumulocity.Client.Model;

/// <summary> 
/// Resources usage for each subscribed microservice application. <br />
/// </summary>
///
public sealed class UsageStatisticsResources 
{
	
    /// <summary> 
    /// Total number of CPU usage for tenant microservices, specified in CPU milliseconds (1000m = 1 CPU). <br />
    /// </summary>
    ///
    [JsonPropertyName("cpu")]
    public int? Cpu { get; set; }
	
    /// <summary> 
    /// Total number of memory usage for tenant microservices, specified in MB. <br />
    /// </summary>
    ///
    [JsonPropertyName("memory")]
    public int? Memory { get; set; }
	
    /// <summary> 
    /// Collection of resources usage for each microservice. <br />
    /// </summary>
    ///
    [JsonPropertyName("usedBy")]
    public IReadOnlyList<UsageStatisticsResourcesUsedBy> UsedBy { get; set; } = Array.Empty<UsageStatisticsResourcesUsedBy>();
	
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