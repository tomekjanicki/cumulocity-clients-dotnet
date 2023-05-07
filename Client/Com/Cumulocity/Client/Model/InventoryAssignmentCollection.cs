///
/// InventoryAssignmentCollection.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Model;

public sealed class InventoryAssignmentCollection 
{
	
    /// <summary> 
    /// A URL linking to this resource. <br />
    /// </summary>
    ///
    [JsonPropertyName("self")]
    public string? Self { get; set; }
	
    /// <summary> 
    /// An array of inventory assignments. <br />
    /// </summary>
    ///
    [JsonPropertyName("inventoryAssignments")]
    public IReadOnlyList<InventoryAssignment> InventoryAssignments { get; set; } = Array.Empty<InventoryAssignment>();
	
    public override string ToString() => JsonSerializerWrapper.SerializeToString(this);
}