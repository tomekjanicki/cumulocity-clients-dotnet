///
/// AuthConfigAccess.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Text.Json.Serialization;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Model;

public sealed class AuthConfigAccess 
{
	
    /// <summary> 
    /// Indicates whether the configuration is only accessible to the management tenant. <br />
    /// </summary>
    ///
    [JsonPropertyName("onlyManagementTenantAccess")]
    public bool? OnlyManagementTenantAccess { get; set; }
	
    public override string ToString() => JsonSerializerWrapper.SerializeToString(this);
}