///
/// InventoryApiResource.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Model;

public sealed class InventoryApiResource<TManagedObject> where TManagedObject : ManagedObject
{
	
    /// <summary> 
    /// Read-only collection of all managed objects with a particular fragment type or capability (placeholder {fragmentType}). <br />
    /// </summary>
    ///
    [JsonPropertyName("managedObjectsForFragmentType")]
    public string? ManagedObjectsForFragmentType { get; set; }
	
    /// <summary> 
    /// Read-only collection of all managed objects of a particular type (placeholder {type}). <br />
    /// </summary>
    ///
    [JsonPropertyName("managedObjectsForType")]
    public string? ManagedObjectsForType { get; set; }
	
    /// <summary> 
    /// Read-only collection of managed objects fetched for a given list of ids, for example, “ids=41,43,68”. <br />
    /// </summary>
    ///
    [JsonPropertyName("managedObjectsForListOfIds")]
    public string? ManagedObjectsForListOfIds { get; set; }
	
    /// <summary> 
    /// Collection of all managed objects <br />
    /// </summary>
    ///
    [JsonPropertyName("managedObjects")]
    public ManagedObjects<TManagedObject>? PManagedObjects { get; set; }
	
    /// <summary> 
    /// A URL linking to this resource. <br />
    /// </summary>
    ///
    [JsonPropertyName("self")]
    public string? Self { get; set; }
	
    /// <summary> 
    /// Collection of all managed objects <br />
    /// </summary>
    ///
    public sealed class ManagedObjects<T> where T : ManagedObject
    {
		
        /// <summary> 
        /// An array containing the referenced managed objects. <br />
        /// </summary>
        ///
        [JsonPropertyName("references")]
        public IReadOnlyList<T> References { get; set; } = Array.Empty<T>();
		
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