///
/// ChildOperationsApi.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Client.Com.Cumulocity.Client.Model;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Api;

/// <summary> 
/// Managed objects can contain collections of references to child devices, additions and assets. <br />
/// ⓘ Info: The Accept header should be provided in all POST requests, otherwise an empty response body will be returned. <br />
/// </summary>
///

public sealed class ChildOperationsApi : IChildOperationsApi
{
    private readonly HttpClient _httpClient;

    internal ChildOperationsApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
	
    /// <inheritdoc />
    public async Task<ManagedObjectReferenceCollection<TManagedObject>?> GetChildAdditions<TManagedObject>(string id, int? currentPage = null, int? pageSize = null, string? query = null, bool? withChildren = null, bool? withChildrenCount = null, bool? withTotalElements = null, bool? withTotalPages = null, CancellationToken cToken = default) where TManagedObject : ManagedObject
    {
        var resourcePath = $"/inventory/managedObjects/{HttpUtility.UrlEncode(id)}/childAdditions";
        var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
        var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
        queryString.AddIfRequired("currentPage", currentPage);
        queryString.AddIfRequired("pageSize", pageSize);
        queryString.AddIfRequired("query", query);
        queryString.AddIfRequired("withChildren", withChildren);
        queryString.AddIfRequired("withChildrenCount", withChildrenCount);
        queryString.AddIfRequired("withTotalElements", withTotalElements);
        queryString.AddIfRequired("withTotalPages", withTotalPages);
        uriBuilder.Query = queryString.ToString();
        using var request = new HttpRequestMessage 
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(uriBuilder.ToString())
        };
        request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.managedobjectreferencecollection+json");
        using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
        await response.EnsureSuccessStatusCodeWithContentInfoIfAvailable().ConfigureAwait(false);
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        return await JsonSerializerWrapper.DeserializeAsync<ManagedObjectReferenceCollection<TManagedObject>?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
    }
		
    /// <inheritdoc />
    public async Task<System.IO.Stream> AssignAsChildAddition(ChildOperationsAddOne body, string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) 
    {
        var jsonNode = body.ToJsonNode<ChildOperationsAddOne>();
        var resourcePath = $"/inventory/managedObjects/{HttpUtility.UrlEncode(id)}/childAdditions";
        var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
        using var request = new HttpRequestMessage 
        {
            Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.managedobjectreference+json"),
            Method = HttpMethod.Post,
            RequestUri = new Uri(uriBuilder.ToString())
        };
        request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
        request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.managedobjectreference+json");
        request.Headers.TryAddWithoutValidation("Accept", "application/json");
        using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
        await response.EnsureSuccessStatusCodeWithContentInfoIfAvailable().ConfigureAwait(false);
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        return responseStream;
    }
		
    /// <inheritdoc />
    public async Task<System.IO.Stream> AssignAsChildAddition(ChildOperationsAddMultiple body, string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) 
    {
        var jsonNode = body.ToJsonNode<ChildOperationsAddMultiple>();
        var resourcePath = $"/inventory/managedObjects/{HttpUtility.UrlEncode(id)}/childAdditions";
        var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
        using var request = new HttpRequestMessage 
        {
            Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.managedobjectreferencecollection+json"),
            Method = HttpMethod.Post,
            RequestUri = new Uri(uriBuilder.ToString())
        };
        request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
        request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.managedobjectreferencecollection+json");
        request.Headers.TryAddWithoutValidation("Accept", "application/json");
        using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
        await response.EnsureSuccessStatusCodeWithContentInfoIfAvailable().ConfigureAwait(false);
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        return responseStream;
    }
		
    /// <inheritdoc />
    public async Task<System.IO.Stream> AssignAsChildAddition<TManagedObject>(TManagedObject body, string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) where TManagedObject : ManagedObject
    {
        var jsonNode = body.ToJsonNode<TManagedObject>();
        jsonNode?.RemoveFromNode("owner");
        jsonNode?.RemoveFromNode("additionParents");
        jsonNode?.RemoveFromNode("lastUpdated");
        jsonNode?.RemoveFromNode("childDevices");
        jsonNode?.RemoveFromNode("childAssets");
        jsonNode?.RemoveFromNode("creationTime");
        jsonNode?.RemoveFromNode("childAdditions");
        jsonNode?.RemoveFromNode("self");
        jsonNode?.RemoveFromNode("assetParents");
        jsonNode?.RemoveFromNode("deviceParents");
        jsonNode?.RemoveFromNode("id");
        var resourcePath = $"/inventory/managedObjects/{HttpUtility.UrlEncode(id)}/childAdditions";
        var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
        using var request = new HttpRequestMessage 
        {
            Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.managedobject+json"),
            Method = HttpMethod.Post,
            RequestUri = new Uri(uriBuilder.ToString())
        };
        request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
        request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.managedobject+json");
        request.Headers.TryAddWithoutValidation("Accept", "application/json");
        using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
        await response.EnsureSuccessStatusCodeWithContentInfoIfAvailable().ConfigureAwait(false);
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        return responseStream;
    }
		
    /// <inheritdoc />
    public async Task<System.IO.Stream> UnassignChildAdditions(ChildOperationsAddMultiple body, string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) 
    {
        var jsonNode = body.ToJsonNode<ChildOperationsAddMultiple>();
        var resourcePath = $"/inventory/managedObjects/{HttpUtility.UrlEncode(id)}/childAdditions";
        var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
        using var request = new HttpRequestMessage 
        {
            Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.managedobjectreferencecollection+json"),
            Method = HttpMethod.Delete,
            RequestUri = new Uri(uriBuilder.ToString())
        };
        request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
        request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.managedobjectreferencecollection+json");
        request.Headers.TryAddWithoutValidation("Accept", "application/json");
        using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
        await response.EnsureSuccessStatusCodeWithContentInfoIfAvailable().ConfigureAwait(false);
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        return responseStream;
    }
		
    /// <inheritdoc />
    public async Task<ManagedObjectReference<TManagedObject>?> GetChildAddition<TManagedObject>(string id, string childId, CancellationToken cToken = default) where TManagedObject : ManagedObject
    {
        var resourcePath = $"/inventory/managedObjects/{HttpUtility.UrlEncode(id)}/childAdditions/{HttpUtility.UrlEncode(childId)}";
        var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
        using var request = new HttpRequestMessage 
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(uriBuilder.ToString())
        };
        request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.managedobjectreference+json, application/vnd.com.nsn.cumulocity.error+json");
        using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
        await response.EnsureSuccessStatusCodeWithContentInfoIfAvailable().ConfigureAwait(false);
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        return await JsonSerializerWrapper.DeserializeAsync<ManagedObjectReference<TManagedObject>?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
    }
		
    /// <inheritdoc />
    public async Task<System.IO.Stream> UnassignChildAddition(string id, string childId, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) 
    {
        var resourcePath = $"/inventory/managedObjects/{HttpUtility.UrlEncode(id)}/childAdditions/{HttpUtility.UrlEncode(childId)}";
        var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
        using var request = new HttpRequestMessage 
        {
            Method = HttpMethod.Delete,
            RequestUri = new Uri(uriBuilder.ToString())
        };
        request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
        request.Headers.TryAddWithoutValidation("Accept", "application/json");
        using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
        await response.EnsureSuccessStatusCodeWithContentInfoIfAvailable().ConfigureAwait(false);
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        return responseStream;
    }
		
    /// <inheritdoc />
    public async Task<ManagedObjectReferenceCollection<TManagedObject>?> GetChildAssets<TManagedObject>(string id, int? currentPage = null, int? pageSize = null, string? query = null, bool? withChildren = null, bool? withChildrenCount = null, bool? withTotalElements = null, bool? withTotalPages = null, CancellationToken cToken = default) where TManagedObject : ManagedObject
    {
        var resourcePath = $"/inventory/managedObjects/{HttpUtility.UrlEncode(id)}/childAssets";
        var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
        var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
        queryString.AddIfRequired("currentPage", currentPage);
        queryString.AddIfRequired("pageSize", pageSize);
        queryString.AddIfRequired("query", query);
        queryString.AddIfRequired("withChildren", withChildren);
        queryString.AddIfRequired("withChildrenCount", withChildrenCount);
        queryString.AddIfRequired("withTotalElements", withTotalElements);
        queryString.AddIfRequired("withTotalPages", withTotalPages);
        uriBuilder.Query = queryString.ToString();
        using var request = new HttpRequestMessage 
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(uriBuilder.ToString())
        };
        request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.managedobjectreferencecollection+json");
        using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
        await response.EnsureSuccessStatusCodeWithContentInfoIfAvailable().ConfigureAwait(false);
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        return await JsonSerializerWrapper.DeserializeAsync<ManagedObjectReferenceCollection<TManagedObject>?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
    }
		
    /// <inheritdoc />
    public async Task<System.IO.Stream> AssignAsChildAsset(ChildOperationsAddOne body, string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) 
    {
        var jsonNode = body.ToJsonNode<ChildOperationsAddOne>();
        var resourcePath = $"/inventory/managedObjects/{HttpUtility.UrlEncode(id)}/childAssets";
        var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
        using var request = new HttpRequestMessage 
        {
            Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.managedobjectreference+json"),
            Method = HttpMethod.Post,
            RequestUri = new Uri(uriBuilder.ToString())
        };
        request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
        request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.managedobjectreference+json");
        request.Headers.TryAddWithoutValidation("Accept", "application/json");
        using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
        await response.EnsureSuccessStatusCodeWithContentInfoIfAvailable().ConfigureAwait(false);
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        return responseStream;
    }
		
    /// <inheritdoc />
    public async Task<System.IO.Stream> AssignAsChildAsset(ChildOperationsAddMultiple body, string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) 
    {
        var jsonNode = body.ToJsonNode<ChildOperationsAddMultiple>();
        var resourcePath = $"/inventory/managedObjects/{HttpUtility.UrlEncode(id)}/childAssets";
        var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
        using var request = new HttpRequestMessage 
        {
            Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.managedobjectreferencecollection+json"),
            Method = HttpMethod.Post,
            RequestUri = new Uri(uriBuilder.ToString())
        };
        request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
        request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.managedobjectreferencecollection+json");
        request.Headers.TryAddWithoutValidation("Accept", "application/json");
        using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
        await response.EnsureSuccessStatusCodeWithContentInfoIfAvailable().ConfigureAwait(false);
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        return responseStream;
    }
		
    /// <inheritdoc />
    public async Task<System.IO.Stream> AssignAsChildAsset<TManagedObject>(TManagedObject body, string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) where TManagedObject : ManagedObject
    {
        var jsonNode = body.ToJsonNode<TManagedObject>();
        jsonNode?.RemoveFromNode("owner");
        jsonNode?.RemoveFromNode("additionParents");
        jsonNode?.RemoveFromNode("lastUpdated");
        jsonNode?.RemoveFromNode("childDevices");
        jsonNode?.RemoveFromNode("childAssets");
        jsonNode?.RemoveFromNode("creationTime");
        jsonNode?.RemoveFromNode("childAdditions");
        jsonNode?.RemoveFromNode("self");
        jsonNode?.RemoveFromNode("assetParents");
        jsonNode?.RemoveFromNode("deviceParents");
        jsonNode?.RemoveFromNode("id");
        var resourcePath = $"/inventory/managedObjects/{HttpUtility.UrlEncode(id)}/childAssets";
        var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
        using var request = new HttpRequestMessage 
        {
            Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.managedobject+json"),
            Method = HttpMethod.Post,
            RequestUri = new Uri(uriBuilder.ToString())
        };
        request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
        request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.managedobject+json");
        request.Headers.TryAddWithoutValidation("Accept", "application/json");
        using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
        await response.EnsureSuccessStatusCodeWithContentInfoIfAvailable().ConfigureAwait(false);
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        return responseStream;
    }
		
    /// <inheritdoc />
    public async Task<System.IO.Stream> UnassignChildAssets(ChildOperationsAddMultiple body, string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) 
    {
        var jsonNode = body.ToJsonNode<ChildOperationsAddMultiple>();
        var resourcePath = $"/inventory/managedObjects/{HttpUtility.UrlEncode(id)}/childAssets";
        var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
        using var request = new HttpRequestMessage 
        {
            Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.managedobjectreferencecollection+json"),
            Method = HttpMethod.Delete,
            RequestUri = new Uri(uriBuilder.ToString())
        };
        request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
        request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.managedobjectreferencecollection+json");
        request.Headers.TryAddWithoutValidation("Accept", "application/json");
        using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
        await response.EnsureSuccessStatusCodeWithContentInfoIfAvailable().ConfigureAwait(false);
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        return responseStream;
    }
		
    /// <inheritdoc />
    public async Task<ManagedObjectReference<TManagedObject>?> GetChildAsset<TManagedObject>(string id, string childId, CancellationToken cToken = default) where TManagedObject : ManagedObject
    {
        var resourcePath = $"/inventory/managedObjects/{HttpUtility.UrlEncode(id)}/childAssets/{HttpUtility.UrlEncode(childId)}";
        var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
        using var request = new HttpRequestMessage 
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(uriBuilder.ToString())
        };
        request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.managedobjectreference+json, application/vnd.com.nsn.cumulocity.error+json");
        using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
        await response.EnsureSuccessStatusCodeWithContentInfoIfAvailable().ConfigureAwait(false);
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        return await JsonSerializerWrapper.DeserializeAsync<ManagedObjectReference<TManagedObject>?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
    }
		
    /// <inheritdoc />
    public async Task<System.IO.Stream> UnassignChildAsset(string id, string childId, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) 
    {
        var resourcePath = $"/inventory/managedObjects/{HttpUtility.UrlEncode(id)}/childAssets/{HttpUtility.UrlEncode(childId)}";
        var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
        using var request = new HttpRequestMessage 
        {
            Method = HttpMethod.Delete,
            RequestUri = new Uri(uriBuilder.ToString())
        };
        request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
        request.Headers.TryAddWithoutValidation("Accept", "application/json");
        using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
        await response.EnsureSuccessStatusCodeWithContentInfoIfAvailable().ConfigureAwait(false);
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        return responseStream;
    }
		
    /// <inheritdoc />
    public async Task<ManagedObjectReferenceCollection<TManagedObject>?> GetChildDevices<TManagedObject>(string id, int? currentPage = null, int? pageSize = null, string? query = null, bool? withChildren = null, bool? withChildrenCount = null, bool? withTotalElements = null, bool? withTotalPages = null, CancellationToken cToken = default) where TManagedObject : ManagedObject
    {
        var resourcePath = $"/inventory/managedObjects/{HttpUtility.UrlEncode(id)}/childDevices";
        var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
        var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
        queryString.AddIfRequired("currentPage", currentPage);
        queryString.AddIfRequired("pageSize", pageSize);
        queryString.AddIfRequired("query", query);
        queryString.AddIfRequired("withChildren", withChildren);
        queryString.AddIfRequired("withChildrenCount", withChildrenCount);
        queryString.AddIfRequired("withTotalElements", withTotalElements);
        queryString.AddIfRequired("withTotalPages", withTotalPages);
        uriBuilder.Query = queryString.ToString();
        using var request = new HttpRequestMessage 
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(uriBuilder.ToString())
        };
        request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.managedobjectreferencecollection+json");
        using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
        await response.EnsureSuccessStatusCodeWithContentInfoIfAvailable().ConfigureAwait(false);
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        return await JsonSerializerWrapper.DeserializeAsync<ManagedObjectReferenceCollection<TManagedObject>?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
    }
		
    /// <inheritdoc />
    public async Task<System.IO.Stream> AssignAsChildDevice(ChildOperationsAddOne body, string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) 
    {
        var jsonNode = body.ToJsonNode<ChildOperationsAddOne>();
        var resourcePath = $"/inventory/managedObjects/{HttpUtility.UrlEncode(id)}/childDevices";
        var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
        using var request = new HttpRequestMessage 
        {
            Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.managedobjectreference+json"),
            Method = HttpMethod.Post,
            RequestUri = new Uri(uriBuilder.ToString())
        };
        request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
        request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.managedobjectreference+json");
        request.Headers.TryAddWithoutValidation("Accept", "application/json");
        using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
        await response.EnsureSuccessStatusCodeWithContentInfoIfAvailable().ConfigureAwait(false);
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        return responseStream;
    }
		
    /// <inheritdoc />
    public async Task<System.IO.Stream> AssignAsChildDevice(ChildOperationsAddMultiple body, string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) 
    {
        var jsonNode = body.ToJsonNode<ChildOperationsAddMultiple>();
        var resourcePath = $"/inventory/managedObjects/{HttpUtility.UrlEncode(id)}/childDevices";
        var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
        using var request = new HttpRequestMessage 
        {
            Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.managedobjectreferencecollection+json"),
            Method = HttpMethod.Post,
            RequestUri = new Uri(uriBuilder.ToString())
        };
        request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
        request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.managedobjectreferencecollection+json");
        request.Headers.TryAddWithoutValidation("Accept", "application/json");
        using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
        await response.EnsureSuccessStatusCodeWithContentInfoIfAvailable().ConfigureAwait(false);
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        return responseStream;
    }
		
    /// <inheritdoc />
    public async Task<System.IO.Stream> AssignAsChildDevice<TManagedObject>(TManagedObject body, string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) where TManagedObject : ManagedObject
    {
        var jsonNode = body.ToJsonNode<TManagedObject>();
        jsonNode?.RemoveFromNode("owner");
        jsonNode?.RemoveFromNode("additionParents");
        jsonNode?.RemoveFromNode("lastUpdated");
        jsonNode?.RemoveFromNode("childDevices");
        jsonNode?.RemoveFromNode("childAssets");
        jsonNode?.RemoveFromNode("creationTime");
        jsonNode?.RemoveFromNode("childAdditions");
        jsonNode?.RemoveFromNode("self");
        jsonNode?.RemoveFromNode("assetParents");
        jsonNode?.RemoveFromNode("deviceParents");
        jsonNode?.RemoveFromNode("id");
        var resourcePath = $"/inventory/managedObjects/{HttpUtility.UrlEncode(id)}/childDevices";
        var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
        using var request = new HttpRequestMessage 
        {
            Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.managedobject+json"),
            Method = HttpMethod.Post,
            RequestUri = new Uri(uriBuilder.ToString())
        };
        request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
        request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.managedobject+json");
        request.Headers.TryAddWithoutValidation("Accept", "application/json");
        using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
        await response.EnsureSuccessStatusCodeWithContentInfoIfAvailable().ConfigureAwait(false);
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        return responseStream;
    }
		
    /// <inheritdoc />
    public async Task<System.IO.Stream> UnassignChildDevices(ChildOperationsAddMultiple body, string id, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) 
    {
        var jsonNode = body.ToJsonNode<ChildOperationsAddMultiple>();
        var resourcePath = $"/inventory/managedObjects/{HttpUtility.UrlEncode(id)}/childDevices";
        var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
        using var request = new HttpRequestMessage 
        {
            Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.managedobjectreferencecollection+json"),
            Method = HttpMethod.Delete,
            RequestUri = new Uri(uriBuilder.ToString())
        };
        request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
        request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.managedobjectreferencecollection+json");
        request.Headers.TryAddWithoutValidation("Accept", "application/json");
        using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
        await response.EnsureSuccessStatusCodeWithContentInfoIfAvailable().ConfigureAwait(false);
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        return responseStream;
    }
		
    /// <inheritdoc />
    public async Task<ManagedObjectReference<TManagedObject>?> GetChildDevice<TManagedObject>(string id, string childId, CancellationToken cToken = default) where TManagedObject : ManagedObject
    {
        var resourcePath = $"/inventory/managedObjects/{HttpUtility.UrlEncode(id)}/childDevices/{HttpUtility.UrlEncode(childId)}";
        var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
        using var request = new HttpRequestMessage 
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(uriBuilder.ToString())
        };
        request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.managedobjectreference+json, application/vnd.com.nsn.cumulocity.error+json");
        using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
        await response.EnsureSuccessStatusCodeWithContentInfoIfAvailable().ConfigureAwait(false);
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        return await JsonSerializerWrapper.DeserializeAsync<ManagedObjectReference<TManagedObject>?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
    }
		
    /// <inheritdoc />
    public async Task<System.IO.Stream> UnassignChildDevice(string id, string childId, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) 
    {
        var resourcePath = $"/inventory/managedObjects/{HttpUtility.UrlEncode(id)}/childDevices/{HttpUtility.UrlEncode(childId)}";
        var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
        using var request = new HttpRequestMessage 
        {
            Method = HttpMethod.Delete,
            RequestUri = new Uri(uriBuilder.ToString())
        };
        request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
        request.Headers.TryAddWithoutValidation("Accept", "application/json");
        using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
        await response.EnsureSuccessStatusCodeWithContentInfoIfAvailable().ConfigureAwait(false);
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        return responseStream;
    }
}
