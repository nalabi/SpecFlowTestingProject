using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowTestingProject.Config
{
    public static class EnvironmentVariables
    {
        public static IConfigurationRoot Configuration { get; }
        static EnvironmentVariables()
        {
            Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())  // Set base path for the appsettings.json file
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
        }
        public static string Username => GetVariable("USERNAME", "defaultUsername");
        public static string Password => GetVariable("PASSWORD", "defaultPassword");
        public static string Url => Configuration["SeleniumSettings:Url"];

        // Helper method to get the environment variable with an optional default value
        private static string GetVariable(string variable, string defaultValue = null)
        {
            string value = Environment.GetEnvironmentVariable(variable);
            return string.IsNullOrEmpty(value) ? defaultValue : value;
        }
    }
}
