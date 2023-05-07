using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace Client.Com.Cumulocity.Client.Supplementary;

internal static class NameValueCollectionExtensions
{
    private static string GetStringValue(this object input)
    {
        if (input is System.DateTime dateTime)
        {
            return dateTime.ToString("O");
        }
        return input.ToString() ?? string.Empty;
    }
	
    public static void AddIfRequired(this NameValueCollection collection, string key, object? value)
    {
        if (value != null)
        {
            collection.Add(key, value.GetStringValue());
        }
    }
	
    public static void AddIfRequired<T>(this NameValueCollection collection, string key, IReadOnlyList<T>? value, bool explode = true)
    {
        if (value == null)
        {
            return;
        }
        if (explode)
        {
            foreach (var item in value.Where(e => e != null))
            {
                collection.Add(key, item!.GetStringValue());
            }
        }
        else
        {
            collection.Add(key, string.Join(',', value.Where(static e => e != null)));
        }
    }
}