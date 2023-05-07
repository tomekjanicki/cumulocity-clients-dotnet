///
/// C8yDistanceMeasurement.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Text.Json.Serialization;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Model;

/// <summary> 
/// Measurement of the distance. <br />
/// </summary>
///
public sealed class C8yDistanceMeasurement 
{
	
    /// <summary> 
    /// A measurement is a value with a unit. <br />
    /// </summary>
    ///
    [JsonPropertyName("distance")]
    public C8yMeasurementValue? Distance { get; set; }
	
    public override string ToString() => JsonSerializerWrapper.SerializeToString(this);
}