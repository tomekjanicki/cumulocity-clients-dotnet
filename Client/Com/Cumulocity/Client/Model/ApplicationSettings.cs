///
/// ApplicationSettings.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Text.Json.Serialization;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Model;

public sealed class ApplicationSettings 
{
	
    /// <summary> 
    /// The name of the setting. <br />
    /// </summary>
    ///
    [JsonPropertyName("key")]
    public string? Key { get; set; }
	
    /// <summary> 
    /// The value schema determines the values that the microservice can process. <br />
    /// </summary>
    ///
    [JsonPropertyName("valueSchema")]
    public ValueSchema? PValueSchema { get; set; }
	
    /// <summary> 
    /// The default value. <br />
    /// </summary>
    ///
    [JsonPropertyName("defaultValue")]
    public string? DefaultValue { get; set; }
	
    /// <summary> 
    /// Indicates if the value is editable. <br />
    /// </summary>
    ///
    [JsonPropertyName("editable")]
    public bool? Editable { get; set; }
	
    /// <summary> 
    /// Indicated wether this setting is inherited. <br />
    /// </summary>
    ///
    [JsonPropertyName("inheritFromOwner")]
    public bool? InheritFromOwner { get; set; }
	
    /// <summary> 
    /// The value schema determines the values that the microservice can process. <br />
    /// </summary>
    ///
    public sealed class ValueSchema 
    {
		
        /// <summary> 
        /// The value schema type. <br />
        /// </summary>
        ///
        [JsonPropertyName("type")]
        public string? Type { get; set; }
		
        public override string ToString() => JsonSerializerWrapper.SerializeToString(this);
    }
	
    public override string ToString() => JsonSerializerWrapper.SerializeToString(this);
}