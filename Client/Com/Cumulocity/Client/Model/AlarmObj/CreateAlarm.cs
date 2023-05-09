using System.Text.Json.Serialization;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Model.AlarmObj;

public class CreateAlarm
{
    /// <summary> 
    /// The severity of the alarm. <br />
    /// </summary>
    ///
    [JsonPropertyName("severity")]
    public Severity? PSeverity { get; set; }

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

    public override string ToString() => JsonSerializerWrapper.SerializeToString(this);
}