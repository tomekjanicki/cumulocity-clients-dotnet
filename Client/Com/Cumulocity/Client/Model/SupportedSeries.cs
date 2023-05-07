///
/// SupportedSeries.cs
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

public sealed class SupportedSeries 
{
	
    /// <summary> 
    /// An array containing all supported measurement series of the specified device. <br />
    /// </summary>
    ///
    [JsonPropertyName("c8y_SupportedSeries")]
    public IReadOnlyList<string> C8ySupportedSeries { get; set; } = Array.Empty<string>();
	
    public override string ToString() => JsonSerializerWrapper.SerializeToString(this);
}