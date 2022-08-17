///
/// SystemOption.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model 
{
	/// <summary>
	/// A tuple storing tenant configuration.
	/// </summary>
	public class SystemOption 
	{
	
		/// <summary>
		/// Name of the system option category.
		/// </summary>
		[JsonPropertyName("category")]
		public string? Category { get; set; }
	
		/// <summary>
		/// A unique identifier for this system option.
		/// </summary>
		[JsonPropertyName("key")]
		public string? Key { get; set; }
	
		/// <summary>
		/// Value of this system option.
		/// </summary>
		[JsonPropertyName("value")]
		public string? Value { get; set; }
	
		public override string ToString()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}
