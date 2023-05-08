///
/// C8yThreePhaseEnergyMeasurement.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Collections.Generic;
using System.Text.Json.Serialization;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Model;

/// <summary> 
/// Measurement of the three phase energy meter. <br />
/// </summary>
///
public sealed class C8yThreePhaseEnergyMeasurement 
{
	
    [JsonPropertyName("additionalProperties")]
    public Dictionary<string, C8yMeasurementValue> AdditionalProperties { get; set; } = new Dictionary<string, C8yMeasurementValue>();
		
    [JsonIgnore]
    public C8yMeasurementValue this[string key]
    {
        get => AdditionalProperties[key];
        set => AdditionalProperties[key] = value;
    }
	
    public override string ToString() => JsonSerializerWrapper.SerializeToString(this);
}