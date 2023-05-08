using System.Collections.Generic;
using System.Text.Json.Serialization;
using Client.Com.Cumulocity.Client.Converter;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Model.AlarmObj;

[JsonConverter(typeof(WithCustomFragmentsJsonConverter<AlarmResult>))]
public class AlarmResult : IWithCustomFragments
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
    /// It is possible to add an arbitrary number of additional properties as a list of key-value pairs, for example, <c>"property1": {}</c>, <c>"property2": "value"</c>. These properties are known as custom fragments and can be of any type, for example, object or string. Each custom fragment is identified by a unique name. <br />
    /// Review the <see href="https://cumulocity.com/guides/concepts/domain-model/#naming-conventions-of-fragments" langword="Naming conventions of fragments" /> as there are characters that can not be used when naming custom fragments. <br />
    /// </summary>
    ///
    [JsonIgnore]
    IDictionary<string, object?> IWithCustomFragments.CustomFragments { get; set; } = new Dictionary<string, object?>();

    public override string ToString() => JsonSerializerWrapper.SerializeToString(this);
}