using Microsoft.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace SeleniumAutomation.Framework
{
    public class AppConfiguration
    {
        private static IConfiguration _configuration;

        private static IConfiguration Configuration
        {
            get
            {
                if (_configuration == null)
                {
                    _configuration = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile(@"appsettings.json", false, false)
                       .AddEnvironmentVariables()
                       .Build();
                }

                return _configuration;
            }
        }

        public static IConfigurationSection GetSection(string key)
        {
            return Configuration.GetSection(key);
        }

        public static string GetConnectionString(string key)
        {
            return Configuration.GetConnectionString(key);
        }

        public static T GetValue<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] T>(string key)
        {
            return Configuration.GetValue<T>(key);
        }
    }
}
