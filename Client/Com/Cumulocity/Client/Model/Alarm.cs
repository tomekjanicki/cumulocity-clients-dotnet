///
/// Alarm.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Client.Com.Cumulocity.Client.Converter;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Model;

public class Alarm
{
	
    /// <summary> 
    /// Number of times that this alarm has been triggered. <br />
    /// </summary>
    ///
    [JsonPropertyName("count")]
    public int? Count { get; set; }
	
    /// <summary> 
    /// The date and time when the alarm was created. <br />
    /// </summary>
    ///
    [JsonPropertyName("creationTime")]
    public System.DateTime? CreationTime { get; set; }
	
    /// <summary> 
    /// The time at which the alarm occurred for the first time. Only present when <c>count</c> is greater than 1. <br />
    /// </summary>
    ///
    [JsonPropertyName("firstOccurrenceTime")]
    public System.DateTime? FirstOccurrenceTime { get; set; }
	
    /// <summary> 
    /// Unique identifier of the alarm. <br />
    /// </summary>
    ///
    [JsonPropertyName("id")]
    public string? Id { get; set; }
	
    /// <summary> 
    /// The date and time when the alarm was last updated. <br />
    /// </summary>
    ///
    [JsonPropertyName("lastUpdated")]
    public System.DateTime? LastUpdated { get; set; }
	
    /// <summary> 
    /// A URL linking to this resource. <br />
    /// </summary>
    ///
    [JsonPropertyName("self")]
    public string? Self { get; set; }
	
    /// <summary> 
    /// The severity of the alarm. <br />
    /// </summary>
    ///
    [JsonPropertyName("severity")]
    public Severity? PSeverity { get; set; }
	
    /// <summary> 
    /// The managed object to which the alarm is associated. <br />
    /// </summary>
    ///
    [JsonPropertyName("source")]
    public Source? PSource { get; set; }
	
    /// <summary> 
    /// The status of the alarm. If not specified, a new alarm will be created as ACTIVE. <br />
    /// </summary>
    ///
    [JsonPropertyName("status")]
    public Status? PStatus { get; set; }
	
    /// <summary> 
    /// Description of the alarm. <br />
    /// </summary>
    ///
    [JsonPropertyName("text")]
    public string? Text { get; set; }
	
    /// <summary> 
    /// The date and time when the alarm is triggered. <br />
    /// </summary>
    ///
    [JsonPropertyName("time")]
    public System.DateTime? Time { get; set; }
	
    /// <summary> 
    /// Identifies the type of this alarm. <br />
    /// </summary>
    ///
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary> 
    /// The severity of the alarm. <br />
    /// </summary>
    ///
    [JsonConverter(typeof(EnumConverterFactory))]
    public enum Severity 
    {
        [EnumMember(Value = "CRITICAL")]
        CRITICAL,
        [EnumMember(Value = "MAJOR")]
        MAJOR,
        [EnumMember(Value = "MINOR")]
        MINOR,
        [EnumMember(Value = "WARNING")]
        WARNING
    }
	
    /// <summary> 
    /// The status of the alarm. If not specified, a new alarm will be created as ACTIVE. <br />
    /// </summary>
    ///
    [JsonConverter(typeof(EnumConverterFactory))]
    public enum Status 
    {
        [EnumMember(Value = "ACTIVE")]
        ACTIVE,
        [EnumMember(Value = "ACKNOWLEDGED")]
        ACKNOWLEDGED,
        [EnumMember(Value = "CLEARED")]
        CLEARED
    }
	
	
    /// <summary> 
    /// The managed object to which the alarm is associated. <br />
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
        /// Human-readable name that is used for representing the object in user interfaces. <br />
        /// </summary>
        ///
        [JsonPropertyName("name")]
        public string? Name { get; set; }
		
        /// <summary> 
        /// A URL linking to this resource. <br />
        /// </summary>
        ///
        [JsonPropertyName("self")]
        public string? Self { get; set; }
		
        public override string ToString() => JsonSerializerWrapper.SerializeToString(this);
    }
	
	
    public override string ToString() => JsonSerializerWrapper.SerializeToString(this);
}