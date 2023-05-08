using System.Text.Json.Serialization;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Model.AlarmObj;

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