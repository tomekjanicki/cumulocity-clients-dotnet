using System.Collections.Generic;

namespace Client.Com.Cumulocity.Client.Converter;

public interface IWithCustomFragments
{
    Dictionary<string, object?> CustomFragments { get; set; }
}