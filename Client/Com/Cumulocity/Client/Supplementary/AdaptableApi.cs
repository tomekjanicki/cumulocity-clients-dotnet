///
/// AdaptableApi.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Client.Com.Cumulocity.Client.Supplementary;

public class AdaptableApi
{
    protected HttpClient HttpClient { get; }
	
    protected AdaptableApi(HttpClient httpClient)
    {
        this.HttpClient = httpClient;
    }
	
    protected static JsonNode? ToJsonNode<T>(T body)
    {
        var jsonString = JsonSerializer.Serialize(body);
        return JsonSerializer.Deserialize<JsonNode>(jsonString);
    }
}