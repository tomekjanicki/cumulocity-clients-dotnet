///
/// C8ySinglePhaseElectricitySensor.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Model;

/// <summary> 
/// In a managed object, a single phase electricity meter is modeled as a simple empty fragment. <br />
/// </summary>
///
public sealed class C8ySinglePhaseElectricitySensor 
{
	
    public override string ToString() => JsonSerializerWrapper.SerializeToString(this);
}