///
/// LoginOptionsApi.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Com.Cumulocity.Client.Model;
using Com.Cumulocity.Client.Supplementary;

namespace Com.Cumulocity.Client.Api 
{
	/// <summary> 
	/// API methods to retrieve the login options configured in the tenant. <br />
	/// More detailed information about the parameters and their meaning can be found in <see href="https://cumulocity.com/guides/users-guide/administration/#changing-settings" langword="Administration > Changing settings" /> in the Users guide. <br />
	/// ⓘ Info: If OAuth external is the only login option shown in the response, the user will be automatically redirected to the SSO login screen. <br />
	/// </summary>
	///
	#nullable enable
	public class LoginOptionsApi : AdaptableApi, ILoginOptionsApi
	{
		public LoginOptionsApi(HttpClient httpClient) : base(httpClient)
		{
		}
	
		/// <inheritdoc />
		public async Task<LoginOptionCollection?> GetLoginOptions(bool? management = null, string? tenantId = null, CancellationToken cToken = default) 
		{
			var client = HttpClient;
			var resourcePath = $"/tenant/loginOptions";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
			queryString.AddIfRequired("management", management);
			queryString.AddIfRequired("tenantId", tenantId);
			uriBuilder.Query = queryString.ToString();
			using var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.loginoptioncollection+json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			await response.EnsureSuccessStatusCodeWithContentInfoIfAvailable().ConfigureAwait(false);;
            await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
			return await JsonSerializer.DeserializeAsync<LoginOptionCollection?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
		}
		
		/// <inheritdoc />
		public async Task<AuthConfig?> CreateLoginOption(AuthConfig body, CancellationToken cToken = default) 
		{
			var jsonNode = ToJsonNode<AuthConfig>(body);
			jsonNode?.RemoveFromNode("self");
			jsonNode?.RemoveFromNode("id");
			var client = HttpClient;
			var resourcePath = $"/tenant/loginOptions";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			using var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.authconfig+json"),
				Method = HttpMethod.Post,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.authconfig+json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.authconfig+json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			await response.EnsureSuccessStatusCodeWithContentInfoIfAvailable().ConfigureAwait(false);;
            await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
			return await JsonSerializer.DeserializeAsync<AuthConfig?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
		}
		
		/// <inheritdoc />
		public async Task<AuthConfig?> GetLoginOption(string typeOrId, CancellationToken cToken = default) 
		{
			var client = HttpClient;
			var resourcePath = $"/tenant/loginOptions/{typeOrId}";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			using var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.authConfig+json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			await response.EnsureSuccessStatusCodeWithContentInfoIfAvailable().ConfigureAwait(false);;
            await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
			return await JsonSerializer.DeserializeAsync<AuthConfig?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
		}
		
		/// <inheritdoc />
		public async Task<AuthConfig?> UpdateLoginOption(AuthConfig body, string typeOrId, string? xCumulocityProcessingMode = null, CancellationToken cToken = default) 
		{
			var jsonNode = ToJsonNode<AuthConfig>(body);
			jsonNode?.RemoveFromNode("self");
			var client = HttpClient;
			var resourcePath = $"/tenant/loginOptions/{typeOrId}";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			using var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.authconfig+json"),
				Method = HttpMethod.Put,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
			request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.authconfig+json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.authconfig+json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			await response.EnsureSuccessStatusCodeWithContentInfoIfAvailable().ConfigureAwait(false);;
            await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
			return await JsonSerializer.DeserializeAsync<AuthConfig?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
		}
		
		/// <inheritdoc />
		public async Task<System.IO.Stream> DeleteLoginOption(string typeOrId, CancellationToken cToken = default) 
		{
			var client = HttpClient;
			var resourcePath = $"/tenant/loginOptions/{typeOrId}";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			using var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Delete,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			await response.EnsureSuccessStatusCodeWithContentInfoIfAvailable().ConfigureAwait(false);;
            await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
			return responseStream;
		}
		
		/// <inheritdoc />
		public async Task<AuthConfig?> UpdateLoginOptionAccess(AuthConfigAccess body, string typeOrId, string? targetTenant = null, CancellationToken cToken = default) 
		{
			var jsonNode = ToJsonNode<AuthConfigAccess>(body);
			var client = HttpClient;
			var resourcePath = $"/tenant/loginOptions/{typeOrId}/restrict";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
			queryString.AddIfRequired("targetTenant", targetTenant);
			uriBuilder.Query = queryString.ToString();
			using var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/json"),
				Method = HttpMethod.Put,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.authconfig+json");
			using var response = await client.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
			await response.EnsureSuccessStatusCodeWithContentInfoIfAvailable().ConfigureAwait(false);;
            await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
			return await JsonSerializer.DeserializeAsync<AuthConfig?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);;
		}
	}
	#nullable disable
}
