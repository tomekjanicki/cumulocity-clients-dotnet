///
/// InventoryAssignment.cs
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
	/// An inventory assignment.
	/// </summary>
	public class InventoryAssignment 
	{
	
		/// <summary>
		/// A unique identifier for this inventory assignment.
		/// </summary>
		[JsonPropertyName("id")]
		public int? Id { get; set; }
	
		/// <summary>
		/// A unique identifier for the managed object for which the roles are assigned.
		/// </summary>
		[JsonPropertyName("managedObject")]
		public string? ManagedObject { get; set; }
	
		/// <summary>
		/// An array of roles that are assigned to the managed object for the user.
		/// </summary>
		[JsonPropertyName("roles")]
		public List<InventoryRole>? Roles { get; set; }
	
		/// <summary>
		/// A URL linking to this resource.
		/// </summary>
		[JsonPropertyName("self")]
		public string? Self { get; set; }
	
		public override string ToString()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}
