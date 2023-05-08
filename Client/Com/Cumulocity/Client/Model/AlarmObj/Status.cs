using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Client.Com.Cumulocity.Client.Converter;

namespace Client.Com.Cumulocity.Client.Model.AlarmObj;

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