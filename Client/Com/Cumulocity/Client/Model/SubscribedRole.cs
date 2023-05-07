///
/// SubscribedRole.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Text.Json.Serialization;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Model;

public sealed class SubscribedRole 
{
	
    /// <summary> 
    /// An object with a role reference URL. <br />
    /// </summary>
    ///
    [JsonPropertyName("role")]
    public Role? PRole { get; set; }
	
    /// <summary> 
    /// An object with a role reference URL. <br />
    /// </summary>
    ///
    public sealed class Role 
    {
		
        /// <summary> 
        /// A URL linking to this resource. <br />
        /// </summary>
        ///
        [JsonPropertyName("self")]
        public string? Self { get; set; }
		
        public override string ToString() => JsonSerializerWrapper.SerializeToString(this);
    }
	
    public override string ToString() => JsonSerializerWrapper.SerializeToString(this);
}