///
/// SupportedMeasurements.cs
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

public sealed class SupportedMeasurements 
{
	
    /// <summary> 
    /// An array containing all supported measurements of the specified managed object. <br />
    /// </summary>
    ///
    [JsonPropertyName("c8y_SupportedMeasurements")]
    public IReadOnlyList<string> C8ySupportedMeasurements { get; set; } = Array.Empty<string>();
	
    public override string ToString() => JsonSerializerWrapper.SerializeToString(this);
}