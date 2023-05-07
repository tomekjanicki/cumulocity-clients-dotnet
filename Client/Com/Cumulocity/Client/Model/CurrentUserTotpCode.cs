///
/// CurrentUserTotpCode.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Text.Json.Serialization;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Model;

public sealed class CurrentUserTotpCode 
{
	
    /// <summary> 
    /// Two-factor authentication code entered by the user to log in to the platform. <br />
    /// </summary>
    ///
    [JsonPropertyName("code")]
    public string? Code { get; set; }
	
    public CurrentUserTotpCode() 
    {
    }
	
    public CurrentUserTotpCode(string code)
    {
        this.Code = code;
    }
	
    public override string ToString() => JsonSerializerWrapper.SerializeToString(this);
}