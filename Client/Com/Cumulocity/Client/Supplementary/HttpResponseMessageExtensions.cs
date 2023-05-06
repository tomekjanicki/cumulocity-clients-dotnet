using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Com.Cumulocity.Client.Supplementary;

public static class HttpResponseMessageExtensions
{
    public static async Task EnsureSuccessStatusCodeWithContentInfoIfAvailable(this HttpResponseMessage httpResponseMessage)
    {
        if (!httpResponseMessage.IsSuccessStatusCode)
        {
            var content = await httpResponseMessage.GetContent().ConfigureAwait(false);
            if (content != string.Empty)
            {
                throw new HttpRequestException($"Request failed. Status code: {httpResponseMessage.StatusCode}, Reason: {httpResponseMessage.ReasonPhrase}, Additional info: {content}");
            }

            throw new HttpRequestException($"Request failed. Status code: {httpResponseMessage.StatusCode}, Reason: {httpResponseMessage.ReasonPhrase}");
        }
    }

    private static async Task<string> GetContent(this HttpResponseMessage httpResponseMessage)
    {
        try
        {
            return await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
        }
        catch
        {
            return string.Empty;
        }
    }
}