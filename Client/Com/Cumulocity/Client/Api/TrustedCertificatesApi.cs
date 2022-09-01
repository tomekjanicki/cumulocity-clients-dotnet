///
/// TrustedCertificatesApi.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Com.Cumulocity.Client.Model;
using Com.Cumulocity.Client.Supplementary;

namespace Com.Cumulocity.Client.Api 
{
	/// <summary>
	/// API methods for managing trusted certificates used to establish device connections via MQTT.
	/// 
	/// More detailed information about trusted certificates and their role can be found in [Device management > Managing device data](https://cumulocity.com/guides/users-guide/device-management/#managing-device-data) in the *User guide*.
	/// 
	/// > **&#9432; Info:** The Accept header must be provided in all POST/PUT requests, otherwise an empty response body will be returned.
	/// 
	/// </summary>
	#nullable enable
	public class TrustedCertificatesApi : AdaptableApi 
	{
		public TrustedCertificatesApi(HttpClient httpClient) : base(httpClient)
		{
		}
	
		/// <summary>
		/// Retrieve all stored certificates<br/>
		/// Retrieve all the trusted certificates of a specific tenant (by a given ID).  <section><h5>Required roles</h5> (ROLE_TENANT_MANAGEMENT_ADMIN <b>OR</b> ROLE_TENANT_ADMIN) <b>AND</b> (is the current tenant) </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the trusted certificates are sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 403</term>
		/// <description>Not authorized to perform this operation.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Tenant not found.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="tenantId">Unique identifier of a Cumulocity IoT tenant.</param>
		/// <param name="currentPage">The current page of the paginated results.</param>
		/// <param name="pageSize">Indicates how many entries of the collection shall be returned. The upper limit for one page is 2,000 objects.</param>
		/// <param name="withTotalElements">When set to `true`, the returned result will contain in the statistics object the total number of elements. Only applicable on [range queries](https://en.wikipedia.org/wiki/Range_query_(database)).</param>
		/// <param name="withTotalPages">When set to `true`, the returned result will contain in the statistics object the total number of pages. Only applicable on [range queries](https://en.wikipedia.org/wiki/Range_query_(database)).</param>
		/// <returns></returns>
		public async Task<TrustedCertificateCollection?> GetTrustedCertificates(string tenantId, int? currentPage = null, int? pageSize = null, bool? withTotalElements = null, bool? withTotalPages = null)
		{
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}/tenant/tenants/{tenantId}/trusted-certificates"));
			var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
			var allQueryParameter = new Dictionary<string, object>()
			{
				#pragma warning disable CS8604 // Possible null reference argument.
				{"currentPage", currentPage},
				{"pageSize", pageSize},
				{"withTotalElements", withTotalElements},
				{"withTotalPages", withTotalPages}
				#pragma warning restore CS8604 // Possible null reference argument.
			};
			allQueryParameter.Where(p => p.Value != null).AsParallel().ForAll(e => queryString.Add(e.Key, $"{e.Value}"));
			uriBuilder.Query = queryString.ToString();
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<TrustedCertificateCollection?>(responseStream);
		}
		
		/// <summary>
		/// Add a new certificate<br/>
		/// Add a new trusted certificate to a specific tenant (by a given ID) which can be further used by the devices to establish connections with the Cumulocity IoT platform.  <section><h5>Required roles</h5> (ROLE_TENANT_MANAGEMENT_ADMIN <b>OR</b> ROLE_TENANT_ADMIN) <b>AND</b> (is the current tenant) </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 201</term>
		/// <description>The certificate was added to the tenant.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Tenant not found.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 409</term>
		/// <description>Duplicate – A certificate with the same fingerprint already exists.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 422</term>
		/// <description>Unprocessable Entity – Invalid certificate data.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="tenantId">Unique identifier of a Cumulocity IoT tenant.</param>
		/// <returns></returns>
		public async Task<TrustedCertificate?> AddTrustedCertificate(TrustedCertificate body, string tenantId)
		{
			var jsonNode = ToJsonNode<TrustedCertificate>(body);
			jsonNode?.RemoveFromNode("notAfter");
			jsonNode?.RemoveFromNode("serialNumber");
			jsonNode?.RemoveFromNode("subject");
			jsonNode?.RemoveFromNode("fingerprint");
			jsonNode?.RemoveFromNode("self");
			jsonNode?.RemoveFromNode("algorithmName");
			jsonNode?.RemoveFromNode("version");
			jsonNode?.RemoveFromNode("issuer");
			jsonNode?.RemoveFromNode("notBefore");
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}/tenant/tenants/{tenantId}/trusted-certificates"));
			var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode.ToString(), Encoding.UTF8, "application/json"),
				Method = HttpMethod.Post,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<TrustedCertificate?>(responseStream);
		}
		
		/// <summary>
		/// Add multiple certificates<br/>
		/// Add multiple trusted certificates to a specific tenant (by a given ID) which can be further used by the devices to establish connections with the Cumulocity IoT platform.  <section><h5>Required roles</h5> (ROLE_TENANT_MANAGEMENT_ADMIN <b>OR</b> ROLE_TENANT_ADMIN) <b>AND</b> (is the current tenant) </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 201</term>
		/// <description>The certificates were added to the tenant.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Tenant not found.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 409</term>
		/// <description>Duplicate – A certificate with the same fingerprint already exists.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 422</term>
		/// <description>Unprocessable Entity – Invalid certificates data.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="tenantId">Unique identifier of a Cumulocity IoT tenant.</param>
		/// <returns></returns>
		public async Task<TrustedCertificateCollection?> AddTrustedCertificates(TrustedCertificateCollection body, string tenantId)
		{
			var jsonNode = ToJsonNode<TrustedCertificateCollection>(body);
			jsonNode?.RemoveFromNode("next");
			jsonNode?.RemoveFromNode("prev");
			jsonNode?.RemoveFromNode("self");
			jsonNode?.RemoveFromNode("statistics");
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}/tenant/tenants/{tenantId}/trusted-certificates/bulk"));
			var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode.ToString(), Encoding.UTF8, "application/json"),
				Method = HttpMethod.Post,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<TrustedCertificateCollection?>(responseStream);
		}
		
		/// <summary>
		/// Retrieve a stored certificate<br/>
		/// Retrieve the data of a stored trusted certificate (by a given fingerprint) of a specific tenant (by a given ID).  <section><h5>Required roles</h5> (ROLE_TENANT_MANAGEMENT_ADMIN <b>OR</b> ROLE_TENANT_ADMIN) <b>AND</b> (is the current tenant <b>OR</b> is the management tenant) </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the trusted certificate is sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="tenantId">Unique identifier of a Cumulocity IoT tenant.</param>
		/// <param name="fingerprint">Unique identifier of a trusted certificate.</param>
		/// <returns></returns>
		public async Task<TrustedCertificate?> GetTrustedCertificate(string tenantId, string fingerprint)
		{
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}/tenant/tenants/{tenantId}/trusted-certificates/{fingerprint}"));
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<TrustedCertificate?>(responseStream);
		}
		
		/// <summary>
		/// Update a stored certificate<br/>
		/// Update the data of a stored trusted certificate (by a given fingerprint) of a specific tenant (by a given ID).  <section><h5>Required roles</h5> (ROLE_TENANT_MANAGEMENT_ADMIN <b>OR</b> ROLE_TENANT_ADMIN) <b>AND</b> (is the current tenant <b>OR</b> is the management tenant) </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The certificate was updated on the tenant.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Certificate not found.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 422</term>
		/// <description>Unprocessable Entity – invalid payload.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <param name="tenantId">Unique identifier of a Cumulocity IoT tenant.</param>
		/// <param name="fingerprint">Unique identifier of a trusted certificate.</param>
		/// <returns></returns>
		public async Task<TrustedCertificate?> UpdateTrustedCertificate(TrustedCertificate body, string tenantId, string fingerprint)
		{
			var jsonNode = ToJsonNode<TrustedCertificate>(body);
			jsonNode?.RemoveFromNode("notAfter");
			jsonNode?.RemoveFromNode("serialNumber");
			jsonNode?.RemoveFromNode("subject");
			jsonNode?.RemoveFromNode("fingerprint");
			jsonNode?.RemoveFromNode("self");
			jsonNode?.RemoveFromNode("certInPemFormat");
			jsonNode?.RemoveFromNode("algorithmName");
			jsonNode?.RemoveFromNode("version");
			jsonNode?.RemoveFromNode("issuer");
			jsonNode?.RemoveFromNode("notBefore");
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}/tenant/tenants/{tenantId}/trusted-certificates/{fingerprint}"));
			var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode.ToString(), Encoding.UTF8, "application/json"),
				Method = HttpMethod.Put,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Content-Type", "application/json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<TrustedCertificate?>(responseStream);
		}
		
		/// <summary>
		/// Remove a stored certificate<br/>
		/// Remove a stored trusted certificate (by a given fingerprint) from a specific tenant (by a given ID).  <section><h5>Required roles</h5> (ROLE_TENANT_MANAGEMENT_ADMIN <b>OR</b> ROLE_TENANT_ADMIN) <b>AND</b> (is the current tenant <b>OR</b> is the management tenant) </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 204</term>
		/// <description>The trusted certificate was removed.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Certificate not found.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="tenantId">Unique identifier of a Cumulocity IoT tenant.</param>
		/// <param name="fingerprint">Unique identifier of a trusted certificate.</param>
		public async Task<System.IO.Stream> RemoveTrustedCertificate(string tenantId, string fingerprint)
		{
			var client = HttpClient;
			var uriBuilder = new UriBuilder(new Uri($"{client?.BaseAddress?.AbsoluteUri}/tenant/tenants/{tenantId}/trusted-certificates/{fingerprint}"));
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Delete,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return responseStream;
		}
	}
	#nullable disable
}