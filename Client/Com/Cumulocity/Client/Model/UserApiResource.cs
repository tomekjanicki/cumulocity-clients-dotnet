///
/// UserApiResource.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model 
{
	public class UserApiResource 
	{
	
		/// <summary>
		/// A URL linking to this resource.
		/// </summary>
		[JsonPropertyName("self")]
		public string? Self { get; set; }
	
		/// <summary>
		/// Collection of all users belonging to a given tenant.
		/// </summary>
		[JsonPropertyName("users")]
		public string? Users { get; set; }
	
		/// <summary>
		/// Reference to a resource of type user.
		/// </summary>
		[JsonPropertyName("userByName")]
		public string? UserByName { get; set; }
	
		/// <summary>
		/// Reference to the resource of the logged in user.
		/// </summary>
		[JsonPropertyName("currentUser")]
		public string? CurrentUser { get; set; }
	
		/// <summary>
		/// Collection of all users belonging to a given tenant.
		/// </summary>
		[JsonPropertyName("groups")]
		public string? Groups { get; set; }
	
		/// <summary>
		/// Reference to a resource of type group.
		/// </summary>
		[JsonPropertyName("groupByName")]
		public string? GroupByName { get; set; }
	
		/// <summary>
		/// Collection of all roles.
		/// </summary>
		[JsonPropertyName("roles")]
		public string? Roles { get; set; }
	
		public override string ToString()
		{
			var jsonOptions = new JsonSerializerOptions() 
			{ 
				WriteIndented = true,
				DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
			};
			return JsonSerializer.Serialize(this, jsonOptions);
		}
	}
}
