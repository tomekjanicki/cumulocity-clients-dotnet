///
/// DeviceCredentialsApi.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Client.Com.Cumulocity.Client.Model;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Api;

/// <summary> 
/// API methods to create device credentials in Cumulocity IoT. <br />
/// Device credentials can be enquired by devices that do not have credentials for accessing a tenant yet.Since the device does not have credentials yet, a set of fixed credentials is used for this API.The credentials can be obtained by <see href="https://cumulocity.com/guides/about-doc/contacting-support/" langword="contacting support" />. <br />
/// ⚠️ Important: Do not use your tenant credentials with this API. <br />
/// ⓘ Info: The Accept header should be provided in all POST requests, otherwise an empty response body will be returned. <br />
/// </summary>
///

public sealed class DeviceCredentialsApi : IDeviceCredentialsApi
{
    private readonly HttpClient _httpClient;

    public DeviceCredentialsApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
	
    /// <inheritdoc />
    public async Task<DeviceCredentials?> CreateDeviceCredentials(DeviceCredentials body, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) 
    {
        var jsonNode = body.ToJsonNode<DeviceCredentials>();
        jsonNode?.RemoveFromNode("password");
        jsonNode?.RemoveFromNode("tenantId");
        jsonNode?.RemoveFromNode("self");
        jsonNode?.RemoveFromNode("username");
        var resourcePath = $"/devicecontrol/deviceCredentials";
        var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
        using var request = new HttpRequestMessage 
        {
            Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.devicecredentials+json"),
            Method = HttpMethod.Post,
            RequestUri = new Uri(uriBuilder.ToString())
        };
        request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
        request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.devicecredentials+json");
        request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.devicecredentials+json");
        using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
        await response.EnsureSuccessStatusCodeWithContentInfoIfAvailable().ConfigureAwait(false);
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        return await JsonSerializer.DeserializeAsync<DeviceCredentials?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
    }
		
    /// <inheritdoc />
    public async Task<BulkNewDeviceRequest?> CreateBulkDeviceCredentials(byte[] file, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) 
    {
        var resourcePath = $"/devicecontrol/bulkNewDeviceRequests";
        var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
        var requestContent = new MultipartFormDataContent();
        var fileContentFile = new ByteArrayContent(file);
        fileContentFile.Headers.ContentType = MediaTypeHeaderValue.Parse("text/csv");
        requestContent.Add(fileContentFile, "file");
        using var request = new HttpRequestMessage 
        {
            Content = requestContent,
            Method = HttpMethod.Post,
            RequestUri = new Uri(uriBuilder.ToString())
        };
        request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
        request.Headers.TryAddWithoutValidation("Content-Type", "multipart/form-data");
        request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.bulknewdevicerequest+json");
        using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
        await response.EnsureSuccessStatusCodeWithContentInfoIfAvailable().ConfigureAwait(false);
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        return await JsonSerializer.DeserializeAsync<BulkNewDeviceRequest?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
    }
}
