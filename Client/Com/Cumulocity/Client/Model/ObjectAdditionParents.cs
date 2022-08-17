///
/// ObjectAdditionParents.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Collections.Generic;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model 
{
	/// <summary>
	/// A collection of references to addition parent objects.
	/// </summary>
	public class ObjectAdditionParents 
	{
	
		/// <summary>
		/// An array with the references to addition parent objects.
		/// </summary>
		[JsonPropertyName("references")]
		public List<ManagedObjectReferenceTuple>? References { get; set; }
	
		/// <summary>
		/// Link to this resource's addition parent objects.
		/// </summary>
		[JsonPropertyName("self")]
		public string? Self { get; set; }
	
		public override string ToString()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}
