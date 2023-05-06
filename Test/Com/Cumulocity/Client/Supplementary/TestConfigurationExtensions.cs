using System.IO;
using Microsoft.Extensions.Configuration;

namespace Test.Com.Cumulocity.Client.Supplementary;

public static class TestConfigurationExtensions
{
	
    public static void Load(this TestConfiguration configuration)
    {
        var configurationRoot = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.test.json", false, false)
            .Build();
        var section = configurationRoot.GetSection("Configuration");
        section.Bind(configuration);
    }
}