///
/// NotificationSubscriptionResult.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using Com.Cumulocity.Client.Converter;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model 
{
	public class NotificationSubscriptionResult 
	{
	
		/// <summary> 
		/// The status of the notification subscription deletion. <br />
		/// </summary>
		///
		[JsonPropertyName("result")]
		public Result? PResult { get; set; }
	
		/// <summary> 
		/// The status of the notification subscription deletion. <br />
		/// </summary>
		///
		[JsonConverter(typeof(EnumConverterFactory))]
		public enum Result 
		{
			[EnumMember(Value = "DONE")]
			DONE,
			[EnumMember(Value = "SCHEDULED")]
			SCHEDULED
		}
	
	
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
