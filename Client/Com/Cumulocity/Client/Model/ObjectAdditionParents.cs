///
/// ObjectAdditionParents.cs
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

/// <summary> 
/// A collection of references to addition parent objects. <br />
/// </summary>
///
public sealed class ObjectAdditionParents 
{
	
    /// <summary> 
    /// An array with the references to addition parent objects. <br />
    /// </summary>
    ///
    [JsonPropertyName("references")]
    public IReadOnlyList<ManagedObjectReferenceTuple> References { get; set; } = Array.Empty<ManagedObjectReferenceTuple>();
	
    /// <summary> 
    /// Link to this resource's addition parent objects. <br />
    /// </summary>
    ///
    [JsonPropertyName("self")]
    public string? Self { get; set; }
	
    public override string ToString() => JsonSerializerWrapper.SerializeToString(this);
}