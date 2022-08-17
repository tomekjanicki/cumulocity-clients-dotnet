///
/// UsageStatisticsResources.cs
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
	/// Resources usage for each subscribed microservice application.
	/// </summary>
	public class UsageStatisticsResources 
	{
	
		/// <summary>
		/// Total number of CPU usage for tenant microservices, specified in CPU milliseconds (1000m = 1 CPU).
		/// </summary>
		[JsonPropertyName("cpu")]
		public int? Cpu { get; set; }
	
		/// <summary>
		/// Total number of memory usage for tenant microservices, specified in MB.
		/// </summary>
		[JsonPropertyName("memory")]
		public int? Memory { get; set; }
	
		/// <summary>
		/// Collection of resources usage for each microservice.
		/// </summary>
		[JsonPropertyName("usedBy")]
		public List<UsageStatisticsResourcesUsedBy>? UsedBy { get; set; }
	
		public override string ToString()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}
