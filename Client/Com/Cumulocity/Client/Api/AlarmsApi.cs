///
/// AlarmsApi.cs
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
	/// An alarm represents an event that requires manual action, for example, when the temperature of a fridge increases above a particular threshold. <br />
	/// ⓘ Info: The Accept header should be provided in all POST/PUT requests, otherwise an empty response body will be returned. <br />
	/// </summary>
	///
	#nullable enable
	public class AlarmsApi : AdaptableApi, IAlarmsApi
	{
		public AlarmsApi(HttpClient httpClient) : base(httpClient)
		{
		}
	
		/// <inheritdoc />
		public async Task<AlarmCollection<TAlarm>?> GetAlarms<TAlarm>(System.DateTime? createdFrom = null, System.DateTime? createdTo = null, int? currentPage = null, System.DateTime? dateFrom = null, System.DateTime? dateTo = null, System.DateTime? lastUpdatedFrom = null, System.DateTime? lastUpdatedTo = null, int? pageSize = null, bool? resolved = null, List<string>? severity = null, string? source = null, List<string>? status = null, List<string>? type = null, bool? withSourceAssets = null, bool? withSourceDevices = null, bool? withTotalElements = null, bool? withTotalPages = null) where TAlarm : Alarm
		{
			var client = HttpClient;
			var resourcePath = $"/alarm/alarms";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
			queryString.AddIfRequired("createdFrom", createdFrom);
			queryString.AddIfRequired("createdTo", createdTo);
			queryString.AddIfRequired("currentPage", currentPage);
			queryString.AddIfRequired("dateFrom", dateFrom);
			queryString.AddIfRequired("dateTo", dateTo);
			queryString.AddIfRequired("lastUpdatedFrom", lastUpdatedFrom);
			queryString.AddIfRequired("lastUpdatedTo", lastUpdatedTo);
			queryString.AddIfRequired("pageSize", pageSize);
			queryString.AddIfRequired("resolved", resolved);
			queryString.AddIfRequired("severity", severity, false);
			queryString.AddIfRequired("source", source);
			queryString.AddIfRequired("status", status, false);
			queryString.AddIfRequired("type", type, false);
			queryString.AddIfRequired("withSourceAssets", withSourceAssets);
			queryString.AddIfRequired("withSourceDevices", withSourceDevices);
			queryString.AddIfRequired("withTotalElements", withTotalElements);
			queryString.AddIfRequired("withTotalPages", withTotalPages);
			uriBuilder.Query = queryString.ToString();
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.alarmcollection+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<AlarmCollection<TAlarm>?>(responseStream);
		}
		
		/// <inheritdoc />
		public async Task<System.IO.Stream> UpdateAlarms<TAlarm>(TAlarm body, string? xCumulocityProcessingMode = null, System.DateTime? createdFrom = null, System.DateTime? createdTo = null, System.DateTime? dateFrom = null, System.DateTime? dateTo = null, bool? resolved = null, List<string>? severity = null, string? source = null, List<string>? status = null, bool? withSourceAssets = null, bool? withSourceDevices = null) where TAlarm : Alarm
		{
			var jsonNode = ToJsonNode<TAlarm>(body);
			jsonNode?.RemoveFromNode("firstOccurrenceTime");
			jsonNode?.RemoveFromNode("severity");
			jsonNode?.RemoveFromNode("lastUpdated");
			jsonNode?.RemoveFromNode("creationTime");
			jsonNode?.RemoveFromNode("count");
			jsonNode?.RemoveFromNode("self");
			jsonNode?.RemoveFromNode("id");
			jsonNode?.RemoveFromNode("source");
			jsonNode?.RemoveFromNode("text");
			jsonNode?.RemoveFromNode("time");
			jsonNode?.RemoveFromNode("type");
			var client = HttpClient;
			var resourcePath = $"/alarm/alarms";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
			queryString.AddIfRequired("createdFrom", createdFrom);
			queryString.AddIfRequired("createdTo", createdTo);
			queryString.AddIfRequired("dateFrom", dateFrom);
			queryString.AddIfRequired("dateTo", dateTo);
			queryString.AddIfRequired("resolved", resolved);
			queryString.AddIfRequired("severity", severity, false);
			queryString.AddIfRequired("source", source);
			queryString.AddIfRequired("status", status, false);
			queryString.AddIfRequired("withSourceAssets", withSourceAssets);
			queryString.AddIfRequired("withSourceDevices", withSourceDevices);
			uriBuilder.Query = queryString.ToString();
			var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode.ToString(), Encoding.UTF8, "application/vnd.com.nsn.cumulocity.alarm+json"),
				Method = HttpMethod.Put,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
			request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.alarm+json");
			request.Headers.TryAddWithoutValidation("Accept", "application/json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return responseStream;
		}
		
		/// <inheritdoc />
		public async Task<TAlarm?> CreateAlarm<TAlarm>(TAlarm body, string? xCumulocityProcessingMode = null) where TAlarm : Alarm
		{
			var jsonNode = ToJsonNode<TAlarm>(body);
			jsonNode?.RemoveFromNode("firstOccurrenceTime");
			jsonNode?.RemoveFromNode("lastUpdated");
			jsonNode?.RemoveFromNode("creationTime");
			jsonNode?.RemoveFromNode("count");
			jsonNode?.RemoveFromNode("self");
			jsonNode?.RemoveFromNode("id");
			jsonNode?.RemoveFromNode("source", "self");
			var client = HttpClient;
			var resourcePath = $"/alarm/alarms";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode.ToString(), Encoding.UTF8, "application/vnd.com.nsn.cumulocity.alarm+json"),
				Method = HttpMethod.Post,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
			request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.alarm+json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.alarm+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<TAlarm?>(responseStream);
		}
		
		/// <inheritdoc />
		public async Task<System.IO.Stream> DeleteAlarms(string? xCumulocityProcessingMode = null, System.DateTime? createdFrom = null, System.DateTime? createdTo = null, System.DateTime? dateFrom = null, System.DateTime? dateTo = null, bool? resolved = null, List<string>? severity = null, string? source = null, List<string>? status = null, List<string>? type = null, bool? withSourceAssets = null, bool? withSourceDevices = null) 
		{
			var client = HttpClient;
			var resourcePath = $"/alarm/alarms";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
			queryString.AddIfRequired("createdFrom", createdFrom);
			queryString.AddIfRequired("createdTo", createdTo);
			queryString.AddIfRequired("dateFrom", dateFrom);
			queryString.AddIfRequired("dateTo", dateTo);
			queryString.AddIfRequired("resolved", resolved);
			queryString.AddIfRequired("severity", severity, false);
			queryString.AddIfRequired("source", source);
			queryString.AddIfRequired("status", status, false);
			queryString.AddIfRequired("type", type, false);
			queryString.AddIfRequired("withSourceAssets", withSourceAssets);
			queryString.AddIfRequired("withSourceDevices", withSourceDevices);
			uriBuilder.Query = queryString.ToString();
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Delete,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
			request.Headers.TryAddWithoutValidation("Accept", "application/json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return responseStream;
		}
		
		/// <inheritdoc />
		public async Task<TAlarm?> GetAlarm<TAlarm>(string id) where TAlarm : Alarm
		{
			var client = HttpClient;
			var resourcePath = $"/alarm/alarms/{id}";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.alarm+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<TAlarm?>(responseStream);
		}
		
		/// <inheritdoc />
		public async Task<TAlarm?> UpdateAlarm<TAlarm>(TAlarm body, string id, string? xCumulocityProcessingMode = null) where TAlarm : Alarm
		{
			var jsonNode = ToJsonNode<TAlarm>(body);
			jsonNode?.RemoveFromNode("firstOccurrenceTime");
			jsonNode?.RemoveFromNode("lastUpdated");
			jsonNode?.RemoveFromNode("creationTime");
			jsonNode?.RemoveFromNode("count");
			jsonNode?.RemoveFromNode("self");
			jsonNode?.RemoveFromNode("id");
			jsonNode?.RemoveFromNode("source");
			jsonNode?.RemoveFromNode("time");
			jsonNode?.RemoveFromNode("type");
			var client = HttpClient;
			var resourcePath = $"/alarm/alarms/{id}";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode.ToString(), Encoding.UTF8, "application/vnd.com.nsn.cumulocity.alarm+json"),
				Method = HttpMethod.Put,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
			request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.alarm+json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.alarm+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<TAlarm?>(responseStream);
		}
		
		/// <inheritdoc />
		public async Task<int> GetNumberOfAlarms(System.DateTime? dateFrom = null, System.DateTime? dateTo = null, bool? resolved = null, List<string>? severity = null, string? source = null, List<string>? status = null, List<string>? type = null, bool? withSourceAssets = null, bool? withSourceDevices = null) 
		{
			var client = HttpClient;
			var resourcePath = $"/alarm/alarms/count";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
			queryString.AddIfRequired("dateFrom", dateFrom);
			queryString.AddIfRequired("dateTo", dateTo);
			queryString.AddIfRequired("resolved", resolved);
			queryString.AddIfRequired("severity", severity, false);
			queryString.AddIfRequired("source", source);
			queryString.AddIfRequired("status", status, false);
			queryString.AddIfRequired("type", type, false);
			queryString.AddIfRequired("withSourceAssets", withSourceAssets);
			queryString.AddIfRequired("withSourceDevices", withSourceDevices);
			uriBuilder.Query = queryString.ToString();
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, text/plain, application/json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<int>(responseStream);
		}
	}
	#nullable disable
}
