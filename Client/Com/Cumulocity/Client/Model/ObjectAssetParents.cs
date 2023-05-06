///
/// ObjectAssetParents.cs
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
/// A collection of references to asset parent objects. <br />
/// </summary>
///
public sealed class ObjectAssetParents 
{
	
    /// <summary> 
    /// An array with the references to asset parent objects. <br />
    /// </summary>
    ///
    [JsonPropertyName("references")]
    public IReadOnlyList<ManagedObjectReferenceTuple> References { get; set; } = Array.Empty<ManagedObjectReferenceTuple>();
	
    /// <summary> 
    /// Link to this resource's asset parent objects. <br />
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