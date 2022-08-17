///
/// C8yLightMeasurement.cs
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
	/// Light is measured with two main alternative sets of units.
	/// 
	/// Radiometry consists of measurements of light power at all wavelengths, while photometry measures light with wavelength weighted with respect to a standardized model of human brightness perception. Photometry is useful, for example, to quantify illumination (lighting) intended for human use.
	/// 
	/// </summary>
	public class C8yLightMeasurement 
	{
	
		/// <summary>
		/// A measurement is a value with a unit.
		/// </summary>
		[JsonPropertyName("e")]
		public C8yMeasurementValue? E { get; set; }
	
		public override string ToString()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}
