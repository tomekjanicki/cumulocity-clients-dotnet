///
/// Operation.cs
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

public class Operation
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
	
	
    public override string ToString() => JsonSerializerWrapper.SerializeToString(this);
}