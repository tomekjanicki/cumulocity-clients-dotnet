///
/// TenantApplicationsApi.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Client.Com.Cumulocity.Client.Model;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Api;

/// <summary> 
/// References to the tenant subscribed applications. <br />
/// ⓘ Info: The Accept header should be provided in all POST requests, otherwise an empty response body will be returned. <br />
/// </summary>
///

public sealed class TenantApplicationsApi : ITenantApplicationsApi
{
    private readonly HttpClient _httpClient;

    internal TenantApplicationsApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
	
    /// <inheritdoc />
    public async Task<ApplicationReferenceCollection?> GetSubscribedApplications(string tenantId, int? currentPage = null, int? pageSize = null, bool? withTotalElements = null, bool? withTotalPages = null, CancellationToken cToken = default) 
    {
        var resourcePath = $"/tenant/tenants/{tenantId}/applications";
        var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
        var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
        queryString.AddIfRequired("currentPage", currentPage);
        queryString.AddIfRequired("pageSize", pageSize);
        queryString.AddIfRequired("withTotalElements", withTotalElements);
        queryString.AddIfRequired("withTotalPages", withTotalPages);
        uriBuilder.Query = queryString.ToString();
        using var request = new HttpRequestMessage 
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(uriBuilder.ToString())
        };
        request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.applicationreferencecollection+json");
        using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
        await response.EnsureSuccessStatusCodeWithContentInfoIfAvailable().ConfigureAwait(false);
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        return await JsonSerializer.DeserializeAsync<ApplicationReferenceCollection?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
    }
		
    /// <inheritdoc />
    public async Task<ApplicationReference?> SubscribeApplication(SubscribedApplicationReference body, string tenantId, CancellationToken cToken = default) 
    {
        var jsonNode = body.ToJsonNode<SubscribedApplicationReference>();
        var resourcePath = $"/tenant/tenants/{tenantId}/applications";
        var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
        using var request = new HttpRequestMessage 
        {
            Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.applicationreference+json"),
            Method = HttpMethod.Post,
            RequestUri = new Uri(uriBuilder.ToString())
        };
        request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.applicationreference+json");
        request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.applicationreference+json");
        using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
        await response.EnsureSuccessStatusCodeWithContentInfoIfAvailable().ConfigureAwait(false);
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        return await JsonSerializer.DeserializeAsync<ApplicationReference?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
    }
		
    /// <inheritdoc />
    public async Task<System.IO.Stream> UnsubscribeApplication(string tenantId, string applicationId, CancellationToken cToken = default) 
    {
        var resourcePath = $"/tenant/tenants/{tenantId}/applications/{applicationId}";
        var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
        using var request = new HttpRequestMessage 
        {
            Method = HttpMethod.Delete,
            RequestUri = new Uri(uriBuilder.ToString())
        };
        request.Headers.TryAddWithoutValidation("Accept", "application/json");
        using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
        await response.EnsureSuccessStatusCodeWithContentInfoIfAvailable().ConfigureAwait(false);
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        return responseStream;
    }
}
