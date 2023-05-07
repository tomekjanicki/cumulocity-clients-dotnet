///
/// LoginOptionCollection.cs
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
/// All available login options of the tenant. <br />
/// </summary>
///
public sealed class LoginOptionCollection 
{
	
    /// <summary> 
    /// An array containing the available login options. <br />
    /// </summary>
    ///
    [JsonPropertyName("loginOptions")]
    public IReadOnlyList<LoginOption> LoginOptions { get; set; } = Array.Empty<LoginOption>();
	
    /// <summary> 
    /// A URL linking to this resource. <br />
    /// </summary>
    ///
    [JsonPropertyName("self")]
    public string? Self { get; set; }
	
    public override string ToString() => JsonSerializerWrapper.SerializeToString(this);
}