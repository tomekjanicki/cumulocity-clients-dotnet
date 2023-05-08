///
/// ApplicationVersion.cs
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

public sealed class ApplicationVersion 
{
	
    /// <summary> 
    /// Unique identifier of the version. <br />
    /// </summary>
    ///
    [JsonPropertyName("version")]
    public string? Version { get; set; }
	
    /// <summary> 
    /// Unique identifier of the binary file assigned to the version. <br />
    /// </summary>
    ///
    [JsonPropertyName("binaryId")]
    public string? BinaryId { get; set; }
	
    /// <summary> 
    /// Tag assigned to the version. Version tags must be unique across all versions and version fields of application versions. <br />
    /// </summary>
    ///
    [JsonPropertyName("tag")]
    public IReadOnlyList<string> Tag { get; set; } = Array.Empty<string>();
	
    public override string ToString() => JsonSerializerWrapper.SerializeToString(this);
}