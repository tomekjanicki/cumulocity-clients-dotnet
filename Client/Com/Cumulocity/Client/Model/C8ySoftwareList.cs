///
/// C8ySoftwareList.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Text.Json.Serialization;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Model;

/// <summary> 
/// Details of the installed software. <br />
/// </summary>
///
public sealed class C8ySoftwareList 
{
	
    /// <summary> 
    /// The name of the software. <br />
    /// </summary>
    ///
    [JsonPropertyName("name")]
    public string? Name { get; set; }
	
    /// <summary> 
    /// The version of the software. <br />
    /// </summary>
    ///
    [JsonPropertyName("version")]
    public string? Version { get; set; }
	
    /// <summary> 
    /// The URL of the software, for example, its code repository. <br />
    /// </summary>
    ///
    [JsonPropertyName("url")]
    public string? Url { get; set; }
	
    public override string ToString() => JsonSerializerWrapper.SerializeToString(this);
}