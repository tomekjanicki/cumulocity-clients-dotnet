using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Client.Com.Cumulocity.Client.Converter;

namespace Client.Com.Cumulocity.Client.Model.AlarmObj;

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