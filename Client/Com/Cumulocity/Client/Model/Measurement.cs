///
/// Measurement.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Text.Json.Serialization;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Model;

public class Measurement
{
	
    /// <summary> 
    /// Unique identifier of the measurement. <br />
    /// </summary>
    ///
    [JsonPropertyName("id")]
    public string? Id { get; set; }
	
    /// <summary> 
    /// A URL linking to this resource. <br />
    /// </summary>
    ///
    [JsonPropertyName("self")]
    public string? Self { get; set; }
	
    /// <summary> 
    /// The managed object to which the measurement is associated. <br />
    /// </summary>
    ///
    [JsonPropertyName("source")]
    public Source? PSource { get; set; }
	
    /// <summary> 
    /// The date and time when the measurement is created. <br />
    /// </summary>
    ///
    [JsonPropertyName("time")]
    public System.DateTime? Time { get; set; }
	
    /// <summary> 
    /// Identifies the type of this measurement. <br />
    /// </summary>
    ///
    [JsonPropertyName("type")]
    public string? Type { get; set; }
	
    /// <summary> 
    /// A type of measurement fragment. <br />
    /// </summary>
    ///
    [JsonPropertyName("c8y_Steam")]
    public C8ySteam? PC8ySteam { get; set; }
    
    public Measurement() 
    {
    }
	
    public Measurement(Source source, System.DateTime time, string type)
    {
        this.PSource = source;
        this.Time = time;
        this.Type = type;
    }
	
    /// <summary> 
    /// The managed object to which the measurement is associated. <br />
    /// </summary>
    ///
    public sealed class Source 
    {
		
        /// <summary> 
        /// Unique identifier of the object. <br />
        /// </summary>
        ///
        [JsonPropertyName("id")]
        public string? Id { get; set; }
		
        /// <summary> 
        /// A URL linking to this resource. <br />
        /// </summary>
        ///
        [JsonPropertyName("self")]
        public string? Self { get; set; }
		
        public Source() 
        {
        }
		
        public Source(string id)
        {
            this.Id = id;
        }
		
        public override string ToString() => JsonSerializerWrapper.SerializeToString(this);
    }
	
    public override string ToString() => JsonSerializerWrapper.SerializeToString(this);
}