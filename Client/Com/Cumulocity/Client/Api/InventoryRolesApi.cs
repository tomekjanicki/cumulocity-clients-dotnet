///
/// InventoryRolesApi.cs
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
using System.Threading.Tasks;
using System.Web;
using Com.Cumulocity.Client.Model;
using Com.Cumulocity.Client.Supplementary;

namespace Com.Cumulocity.Client.Api 
{
	/// <summary> 
	/// API methods to create, retrieve, update and delete inventory roles. <br />
	/// ⓘ Info: The Accept header should be provided in all POST/PUT requests, otherwise an empty response body will be returned. <br />
	/// </summary>
	///
	#nullable enable
	public class InventoryRolesApi : AdaptableApi, IInventoryRolesApi
	{
		public InventoryRolesApi(HttpClient httpClient) : base(httpClient)
		{
		}
	
		/// <inheritdoc />
		public async Task<InventoryRoleCollection?> GetInventoryRoles(int? currentPage = null, int? pageSize = null, bool? withTotalElements = null) 
		{
			var client = HttpClient;
			var resourcePath = $"/user/inventoryroles";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
			queryString.AddIfRequired("currentPage", currentPage);
			queryString.AddIfRequired("pageSize", pageSize);
			queryString.AddIfRequired("withTotalElements", withTotalElements);
			uriBuilder.Query = queryString.ToString();
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.inventoryrolecollection+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<InventoryRoleCollection?>(responseStream);
		}
		
		/// <inheritdoc />
		public async Task<InventoryRole?> CreateInventoryRole(InventoryRole body) 
		{
			var jsonNode = ToJsonNode<InventoryRole>(body);
			jsonNode?.RemoveFromNode("self");
			jsonNode?.RemoveFromNode("id");
			var client = HttpClient;
			var resourcePath = $"/user/inventoryroles";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode.ToString(), Encoding.UTF8, "application/vnd.com.nsn.cumulocity.inventoryrole+json"),
				Method = HttpMethod.Post,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.inventoryrole+json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.inventoryrole+json, application/vnd.com.nsn.cumulocity.error+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<InventoryRole?>(responseStream);
		}
		
		/// <inheritdoc />
		public async Task<InventoryRole?> GetInventoryRole(int id) 
		{
			var client = HttpClient;
			var resourcePath = $"/user/inventoryroles/{id}";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.inventoryrole+json, application/vnd.com.nsn.cumulocity.error+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<InventoryRole?>(responseStream);
		}
		
		/// <inheritdoc />
		public async Task<InventoryRole?> UpdateInventoryRole(InventoryRole body, int id) 
		{
			var jsonNode = ToJsonNode<InventoryRole>(body);
			jsonNode?.RemoveFromNode("self");
			jsonNode?.RemoveFromNode("id");
			var client = HttpClient;
			var resourcePath = $"/user/inventoryroles/{id}";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode.ToString(), Encoding.UTF8, "application/vnd.com.nsn.cumulocity.inventoryrole+json"),
				Method = HttpMethod.Put,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.inventoryrole+json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.inventoryrole+json, application/vnd.com.nsn.cumulocity.error+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<InventoryRole?>(responseStream);
		}
		
		/// <inheritdoc />
		public async Task<System.IO.Stream> DeleteInventoryRole(int id) 
		{
			var client = HttpClient;
			var resourcePath = $"/user/inventoryroles/{id}";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
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
		
		/// <inheritdoc />
		public async Task<InventoryAssignmentCollection?> GetUserInventoryRoles(string tenantId, string userId) 
		{
			var client = HttpClient;
			var resourcePath = $"/user/{tenantId}/users/{userId}/roles/inventory";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.inventoryassignmentcollection+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<InventoryAssignmentCollection?>(responseStream);
		}
		
		/// <inheritdoc />
		public async Task<InventoryAssignment?> AssignUserInventoryRole(InventoryAssignment body, string tenantId, string userId) 
		{
			var jsonNode = ToJsonNode<InventoryAssignment>(body);
			jsonNode?.RemoveFromNode("self");
			jsonNode?.RemoveFromNode("id");
			var client = HttpClient;
			var resourcePath = $"/user/{tenantId}/users/{userId}/roles/inventory";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode.ToString(), Encoding.UTF8, "application/vnd.com.nsn.cumulocity.inventoryassignment+json"),
				Method = HttpMethod.Post,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.inventoryassignment+json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.inventoryassignment+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<InventoryAssignment?>(responseStream);
		}
		
		/// <inheritdoc />
		public async Task<InventoryAssignment?> GetUserInventoryRole(string tenantId, string userId, int id) 
		{
			var client = HttpClient;
			var resourcePath = $"/user/{tenantId}/users/{userId}/roles/inventory/{id}";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.inventoryassignment+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<InventoryAssignment?>(responseStream);
		}
		
		/// <inheritdoc />
		public async Task<InventoryAssignment?> UpdateUserInventoryRole(InventoryAssignmentReference body, string tenantId, string userId, int id) 
		{
			var jsonNode = ToJsonNode<InventoryAssignmentReference>(body);
			var client = HttpClient;
			var resourcePath = $"/user/{tenantId}/users/{userId}/roles/inventory/{id}";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode.ToString(), Encoding.UTF8, "application/vnd.com.nsn.cumulocity.inventoryassignment+json"),
				Method = HttpMethod.Put,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.inventoryassignment+json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.inventoryassignment+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<InventoryAssignment?>(responseStream);
		}
		
		/// <inheritdoc />
		public async Task<System.IO.Stream> UnassignUserInventoryRole(string tenantId, string userId, int id) 
		{
			var client = HttpClient;
			var resourcePath = $"/user/{tenantId}/users/{userId}/roles/inventory/{id}";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
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
