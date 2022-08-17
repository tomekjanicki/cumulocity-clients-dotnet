///
/// SupportedMeasurements.cs
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
	public class SupportedMeasurements 
	{
	
		/// <summary>
		/// An array containing all supported measurements of the specified managed object.
		/// </summary>
		[JsonPropertyName("c8y_SupportedMeasurements")]
		public List<string>? C8ySupportedMeasurements { get; set; }
	
		public override string ToString()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}
