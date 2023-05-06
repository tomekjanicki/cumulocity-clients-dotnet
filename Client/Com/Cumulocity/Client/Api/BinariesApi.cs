///
/// BinariesApi.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Client.Com.Cumulocity.Client.Model;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Api;

/// <summary> 
/// Managed objects can perform operations to store, retrieve and delete binaries. One binary can store only one file. Together with the binary, a managed object is created which acts as a metadata information for the binary. <br />
/// ⓘ Info: The Accept header should be provided in all POST/PUT requests, otherwise an empty response body will be returned. <br />
/// </summary>
///

public sealed class BinariesApi : IBinariesApi
{
    private readonly HttpClient _httpClient;

    public BinariesApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
	
    /// <inheritdoc />
    public async Task<BinaryCollection?> GetBinaries(string? childAdditionId = null, string? childAssetId = null, string? childDeviceId = null, int? currentPage = null, IReadOnlyList<string>? ids = null, string? owner = null, int? pageSize = null, string? text = null, string? type = null, bool? withTotalPages = null, CancellationToken cToken = default) 
    {
        const string resourcePath = "/inventory/binaries";
        var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
        var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
        queryString.AddIfRequired("childAdditionId", childAdditionId);
        queryString.AddIfRequired("childAssetId", childAssetId);
        queryString.AddIfRequired("childDeviceId", childDeviceId);
        queryString.AddIfRequired("currentPage", currentPage);
        queryString.AddIfRequired("ids", ids, false);
        queryString.AddIfRequired("owner", owner);
        queryString.AddIfRequired("pageSize", pageSize);
        queryString.AddIfRequired("text", text);
        queryString.AddIfRequired("type", type);
        queryString.AddIfRequired("withTotalPages", withTotalPages);
        uriBuilder.Query = queryString.ToString();
        using var request = new HttpRequestMessage 
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(uriBuilder.ToString())
        };
        request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.managedobjectcollection+json");
        using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
        await response.EnsureSuccessStatusCodeWithContentInfoIfAvailable().ConfigureAwait(false);
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        return await JsonSerializer.DeserializeAsync<BinaryCollection?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
    }
		
    /// <inheritdoc />
    public async Task<Binary?> UploadBinary(BinaryInfo pObject, byte[] file, CancellationToken cToken = default) 
    {
        const string resourcePath = "/inventory/binaries";
        var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
        var requestContent = new MultipartFormDataContent();
        var fileContentObject = new StringContent(JsonSerializer.Serialize(pObject));
        fileContentObject.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
        requestContent.Add(fileContentObject, "object");
        var fileContentFile = new ByteArrayContent(file);
        fileContentFile.Headers.ContentType = MediaTypeHeaderValue.Parse("text/plain");
        requestContent.Add(fileContentFile, "file");
        using var request = new HttpRequestMessage 
        {
            Content = requestContent,
            Method = HttpMethod.Post,
            RequestUri = new Uri(uriBuilder.ToString())
        };
        request.Headers.TryAddWithoutValidation("Content-Type", "multipart/form-data");
        request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.managedobject+json");
        using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
        await response.EnsureSuccessStatusCodeWithContentInfoIfAvailable().ConfigureAwait(false);
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        return await JsonSerializer.DeserializeAsync<Binary?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
    }
		
    /// <inheritdoc />
    public async Task<System.IO.Stream> GetBinary(string id, CancellationToken cToken = default) 
    {
        var resourcePath = $"/inventory/binaries/{id}";
        var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
        using var request = new HttpRequestMessage 
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(uriBuilder.ToString())
        };
        request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/octet-stream");
        using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
        await response.EnsureSuccessStatusCodeWithContentInfoIfAvailable().ConfigureAwait(false);
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        return responseStream;
    }
		
    /// <inheritdoc />
    public async Task<Binary?> ReplaceBinary(byte[] body, string id, CancellationToken cToken = default) 
    {
        var resourcePath = $"/inventory/binaries/{id}";
        var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
        using var request = new HttpRequestMessage 
        {
            Content = new ByteArrayContent(body),
            Method = HttpMethod.Put,
            RequestUri = new Uri(uriBuilder.ToString())
        };
        request.Headers.TryAddWithoutValidation("Content-Type", "text/plain");
        request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.managedobject+json");
        using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
        await response.EnsureSuccessStatusCodeWithContentInfoIfAvailable().ConfigureAwait(false);
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        return await JsonSerializer.DeserializeAsync<Binary?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
    }
		
    /// <inheritdoc />
    public async Task<System.IO.Stream> RemoveBinary(string id, CancellationToken cToken = default) 
    {
        var resourcePath = $"/inventory/binaries/{id}";
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
