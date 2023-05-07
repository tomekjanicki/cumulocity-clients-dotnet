using System.Collections.Generic;

namespace Client.Com.Cumulocity.Client.Converter;

internal interface IWithCustomFragments
{
    IDictionary<string, object?> CustomFragments { get; set; }
}