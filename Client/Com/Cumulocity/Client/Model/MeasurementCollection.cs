///
/// MeasurementCollection.cs
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

public sealed class MeasurementCollection<TMeasurement> where TMeasurement : Measurement
{
	
    /// <summary> 
    /// An array containing the measurements of the request. <br />
    /// </summary>
    ///
    [JsonPropertyName("measurements")]
    public IReadOnlyList<TMeasurement> Measurements { get; set; } = Array.Empty<TMeasurement>();
	
    /// <summary> 
    /// A URI reference [<see href="https://tools.ietf.org/html/rfc3986" langword="RFC3986" />] to a potential next page of managed objects. <br />
    /// </summary>
    ///
    [JsonPropertyName("next")]
    public string? Next { get; set; }
	
    /// <summary> 
    /// A URI reference [<see href="https://tools.ietf.org/html/rfc3986" langword="RFC3986" />] to a potential previous page of managed objects. <br />
    /// </summary>
    ///
    [JsonPropertyName("prev")]
    public string? Prev { get; set; }
	
    /// <summary> 
    /// A URL linking to this resource. <br />
    /// </summary>
    ///
    [JsonPropertyName("self")]
    public string? Self { get; set; }
	
    /// <summary> 
    /// Information about paging statistics. <br />
    /// </summary>
    ///
    [JsonPropertyName("statistics")]
    public PageStatistics? Statistics { get; set; }
	
    public MeasurementCollection() 
    {
    }
	
    public MeasurementCollection(List<TMeasurement> measurements)
    {
        this.Measurements = measurements;
    }
	
    public override string ToString() => JsonSerializerWrapper.SerializeToString(this);
}