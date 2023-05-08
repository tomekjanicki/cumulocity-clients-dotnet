///
/// Event.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Collections.Generic;
using System.Text.Json.Serialization;
using Client.Com.Cumulocity.Client.Converter;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Model;

[JsonConverter(typeof(EventJsonConverter<Event>))]
public class Event : IWithCustomFragments
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
    /// It is possible to add an arbitrary number of additional properties as a list of key-value pairs, for example, <c>"property1": {}</c>, <c>"property2": "value"</c>. These properties are known as custom fragments and can be of any type, for example, object or string. Each custom fragment is identified by a unique name. <br />
    /// Review the <see href="https://cumulocity.com/guides/concepts/domain-model/#naming-conventions-of-fragments" langword="Naming conventions of fragments" /> as there are characters that can not be used when naming custom fragments. <br />
    /// </summary>
    ///
    [JsonPropertyName("customFragments")]
    public IDictionary<string, object?> CustomFragments { get; set; } = new Dictionary<string, object?>();
		
    [JsonIgnore]
    public object? this[string key]
    {
        get => CustomFragments[key];
        set => CustomFragments[key] = value;
    }
	
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

    private static readonly Dictionary<string, System.Type> AdditionalPropertyClasses = new();

    public static bool TryAddProperty(string key, System.Type type)
    {
        return AdditionalPropertyClasses.TryAdd(key, type);
    }

    internal sealed class EventJsonConverter<T> : BaseWithCustomFragmentsJsonConverter<T> where T : Event
    {
        public EventJsonConverter() : base(AdditionalPropertyClasses)
        {
        }
    }
}