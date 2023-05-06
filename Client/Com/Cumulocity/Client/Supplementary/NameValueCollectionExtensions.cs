using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace Client.Com.Cumulocity.Client.Supplementary;

public static class NameValueCollectionExtensions
{
    public static string GetStringValue(this object input)
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
	
    public static void AddIfRequired<T>(this NameValueCollection collection, string key, List<T>? value, bool explode = true)
    {
        if (value != null)
        {
            if (explode)
            {
                value.Where(e => e != null).ToList().ForEach(e => collection.Add(key, e.GetStringValue()));
            }
            else
            {
                collection.Add(key, string.Join(',', value.Where(e => e != null)));
            }
        }
    }
}