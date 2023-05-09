///
/// Event.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Text.Json.Serialization;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Model;

public class Event
{
	
    /// <summary> 
    /// The date and time when the event was created. <br />
    /// </summary>
    ///
    [JsonPropertyName("creationTime")]
    public System.DateTime? CreationTime { get; set; }
	
    /// <summary> 
    /// The date and time when the event was last updated. <br />
    /// </summary>
    ///
    [JsonPropertyName("lastUpdated")]
    public System.DateTime? LastUpdated { get; set; }
	
    /// <summary> 
    /// Unique identifier of the event. <br />
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
    /// The managed object to which the event is associated. <br />
    /// </summary>
    ///
    [JsonPropertyName("source")]
    public Source? PSource { get; set; }
	
    /// <summary> 
    /// Description of the event. <br />
    /// </summary>
    ///
    [JsonPropertyName("text")]
    public string? Text { get; set; }
	
    /// <summary> 
    /// The date and time when the event is updated. <br />
    /// </summary>
    ///
    [JsonPropertyName("time")]
    public System.DateTime? Time { get; set; }
	
    /// <summary> 
    /// Identifies the type of this event. <br />
    /// </summary>
    ///
    [JsonPropertyName("type")]
    public string? Type { get; set; }
    
    /// <summary> 
    /// The managed object to which the event is associated. <br />
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
		
        public override string ToString() => JsonSerializerWrapper.SerializeToString(this);
    }
	
    public override string ToString() => JsonSerializerWrapper.SerializeToString(this);
}