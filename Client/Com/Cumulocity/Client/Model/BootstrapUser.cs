///
/// BootstrapUser.cs
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
	public class BootstrapUser 
	{
	
		/// <summary>
		/// The bootstrap user tenant username.
		/// </summary>
		[JsonPropertyName("name")]
		public string? Name { get; set; }
	
		/// <summary>
		/// The bootstrap user tenant password.
		/// </summary>
		[JsonPropertyName("password")]
		public string? Password { get; set; }
	
		/// <summary>
		/// The bootstrap user tenant ID.
		/// </summary>
		[JsonPropertyName("tenant")]
		public string? Tenant { get; set; }
	
		public override string ToString()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}
