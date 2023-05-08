///
/// NotificationApiResource.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Model;

public sealed class NotificationApiResource 
{
	
    /// <summary> 
    /// A URL linking to this resource. <br />
    /// </summary>
    ///
    [JsonPropertyName("self")]
    public string? Self { get; set; }
	
    /// <summary> 
    /// Collection of all notification subscriptions. <br />
    /// </summary>
    ///
    [JsonPropertyName("notificationSubscriptions")]
    public NotificationSubscriptions? PNotificationSubscriptions { get; set; }
	
    /// <summary> 
    /// Read-only collection of all notification subscriptions for a specific source object. The placeholder {source} must be a unique ID of an object in the inventory. <br />
    /// </summary>
    ///
    [JsonPropertyName("notificationSubscriptionsBySource")]
    public string? NotificationSubscriptionsBySource { get; set; }
	
    /// <summary> 
    /// Read-only collection of all notification subscriptions of a particular context and a specific source object. <br />
    /// </summary>
    ///
    [JsonPropertyName("notificationSubscriptionsBySourceAndContext")]
    public string? NotificationSubscriptionsBySourceAndContext { get; set; }
	
    /// <summary> 
    /// Read-only collection of all notification subscriptions of a particular context. <br />
    /// </summary>
    ///
    [JsonPropertyName("notificationSubscriptionsByContext")]
    public string? NotificationSubscriptionsByContext { get; set; }
	
    /// <summary> 
    /// Collection of all notification subscriptions. <br />
    /// </summary>
    ///
    public sealed class NotificationSubscriptions 
    {
		
        /// <summary> 
        /// A URL linking to this resource. <br />
        /// </summary>
        ///
        [JsonPropertyName("self")]
        public string? Self { get; set; }
		
        [JsonPropertyName("subscriptions")]
        public IReadOnlyList<NotificationSubscription> Subscriptions { get; set; } = Array.Empty<NotificationSubscription>();
		
        public override string ToString() => JsonSerializerWrapper.SerializeToString(this);
    }
	
    public override string ToString() => JsonSerializerWrapper.SerializeToString(this);
}