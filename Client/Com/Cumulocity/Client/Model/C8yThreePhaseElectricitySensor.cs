///
/// C8yThreePhaseElectricitySensor.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Com.Cumulocity.Client.Model;

/// <summary> 
/// In a managed object, a three phase electricity meter is modeled as a simple empty fragment. <br />
/// </summary>
///
public class C8yThreePhaseElectricitySensor 
{
	
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