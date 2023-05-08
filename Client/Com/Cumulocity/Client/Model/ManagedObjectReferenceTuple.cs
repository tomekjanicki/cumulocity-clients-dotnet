///
/// ManagedObjectReferenceTuple.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Text.Json.Serialization;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Model;

public sealed class ManagedObjectReferenceTuple 
{
	
    /// <summary> 
    /// Details of the referenced managed object. <br />
    /// </summary>
    ///
    [JsonPropertyName("managedObject")]
    public ManagedObject? PManagedObject { get; set; }
	
    /// <summary> 
    /// A URL linking to this resource. <br />
    /// </summary>
    ///
    [JsonPropertyName("self")]
    public string? Self { get; set; }
	
    /// <summary> 
    /// Details of the referenced managed object. <br />
    /// </summary>
    ///
    public sealed class ManagedObject 
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
	
    public override string ToString() => JsonSerializerWrapper.SerializeToString(this);
}