///
/// PasswordChange.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Text.Json.Serialization;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Model;

public sealed class PasswordChange 
{
	
    /// <summary> 
    /// The current password of the user performing the request. <br />
    /// </summary>
    ///
    [JsonPropertyName("currentUserPassword")]
    public string? CurrentUserPassword { get; set; }
	
    /// <summary> 
    /// The new password to be set for the user performing the request. <br />
    /// </summary>
    ///
    [JsonPropertyName("newPassword")]
    public string? NewPassword { get; set; }
	
    public PasswordChange() 
    {
    }
	
    public PasswordChange(string currentUserPassword, string newPassword)
    {
        this.CurrentUserPassword = currentUserPassword;
        this.NewPassword = newPassword;
    }
	
    public override string ToString() => JsonSerializerWrapper.SerializeToString(this);
}