using System.Collections.Generic;
using System.Text.Json;

namespace Client.Com.Cumulocity.Client.Converter;

internal sealed class DictionaryLookupNamingPolicy : JsonNamingPolicy
{
	
    private readonly Dictionary<string, string> _literalNames;
	
    public DictionaryLookupNamingPolicy(Dictionary<string, string> literalNames) => _literalNames = literalNames;
	
    public override string ConvertName(string name)
    {
        return _literalNames.TryGetValue(name, out var value) ? value : name;
    }
}