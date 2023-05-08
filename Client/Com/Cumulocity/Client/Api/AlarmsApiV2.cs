using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Client.Com.Cumulocity.Client.Model.AlarmObj;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Api;

public sealed class AlarmsApiV2 : IAlarmsApiV2
{
    private readonly HttpClient _httpClient;

    internal AlarmsApiV2(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<TAlarmResult?> CreateAlarm<TCreateAlarm, TAlarmResult>(TCreateAlarm body, string? xCumulocityProcessingMode = null, CancellationToken cToken = default)
        where TCreateAlarm : CreateAlarm
        where TAlarmResult : AlarmResult
    {
        const string resourcePath = "/alarm/alarms";
        var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
        using var request = new HttpRequestMessage
        {
            Content = new ByteArrayContent(JsonSerializerWrapper.SerializeToUtf8Bytes(body)),
            Method = HttpMethod.Post,
            RequestUri = new Uri(uriBuilder.ToString())
        };
        request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
        request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.alarm+json");
        request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.alarm+json");
        using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
        await response.EnsureSuccessStatusCodeWithContentInfoIfAvailable().ConfigureAwait(false);
        await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        return await JsonSerializerWrapper.DeserializeAsync<TAlarmResult?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
    }
}