///
/// Operation.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Client.Com.Cumulocity.Client.Converter;

namespace Client.Com.Cumulocity.Client.Model;

[JsonConverter(typeof(OperationJsonConverter<Operation>))]
public class Operation : IWithCustomFragments
{
	
    /// <summary> 
    /// Reference to a bulk operation ID if this operation was scheduled from a bulk operation. <br />
    /// </summary>
    ///
    [JsonPropertyName("bulkOperationId")]
    public string? BulkOperationId { get; set; }
	
    /// <summary> 
    /// Date and time when the operation was created in the database. <br />
    /// </summary>
    ///
    [JsonPropertyName("creationTime")]
    public System.DateTime? CreationTime { get; set; }
	
    /// <summary> 
    /// Identifier of the target device where the operation should be performed. <br />
    /// </summary>
    ///
    [JsonPropertyName("deviceId")]
    public string? DeviceId { get; set; }
	
    [JsonPropertyName("deviceExternalIDs")]
    public ExternalIds? DeviceExternalIDs { get; set; }
	
    /// <summary> 
    /// Reason for the failure. <br />
    /// </summary>
    ///
    [JsonPropertyName("failureReason")]
    public string? FailureReason { get; set; }
	
    /// <summary> 
    /// Unique identifier of this operation. <br />
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
    /// The status of the operation. <br />
    /// </summary>
    ///
    [JsonPropertyName("status")]
    public Status? PStatus { get; set; }
	
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
    /// The status of the operation. <br />
    /// </summary>
    ///
    [JsonConverter(typeof(EnumConverterFactory))]
    public enum Status 
    {
        [EnumMember(Value = "SUCCESSFUL")]
        SUCCESSFUL,
        [EnumMember(Value = "FAILED")]
        FAILED,
        [EnumMember(Value = "EXECUTING")]
        EXECUTING,
        [EnumMember(Value = "PENDING")]
        PENDING
    }
	
	
    public override string ToString()
    {
        var jsonOptions = new JsonSerializerOptions() 
        { 
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };
        return JsonSerializer.Serialize(this, jsonOptions);
    }

    private static readonly Dictionary<string, System.Type> AdditionalPropertyClasses = new();

    public static bool TryAddProperty(string key, System.Type type)
    {
        return AdditionalPropertyClasses.TryAdd(key, type);
    }

    public sealed class OperationJsonConverter<T> : BaseWithCustomFragmentsJsonConverter<T> where T : Operation
    {
        public OperationJsonConverter() : base(AdditionalPropertyClasses)
        {
        }
    }
}