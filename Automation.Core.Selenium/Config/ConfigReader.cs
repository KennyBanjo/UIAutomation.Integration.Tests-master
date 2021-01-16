using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Automation.Core.Selenium.Config
{
    public class ConfigReader
    {
        public static void SetFrameworkSettings()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            IConfigurationRoot configurationRoot = builder.Build();

            Settings.Url = configurationRoot.GetSection("testSettings").Get<TestSettings>().Url;
            Settings.Username = configurationRoot.GetSection("testSettings").Get<TestSettings>().Username;
            Settings.Password = configurationRoot.GetSection("testSettings").Get<TestSettings>().Password;
            Settings.ApiUrl = configurationRoot.GetSection("testSettings").Get<TestSettings>().ApiUrl;
        }
    }
}
