using System.Collections.Generic;

namespace Client.Com.Cumulocity.Client.Converter;

public interface IWithCustomFragments
{
    IDictionary<string, object?> CustomFragments { get; set; }
}