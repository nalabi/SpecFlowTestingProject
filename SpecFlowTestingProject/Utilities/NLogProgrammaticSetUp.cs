using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowTestingProject.Utilities
{
    public static class NLogProgrammaticSetup
    {
        public static void Setup()
        {
            var config = new LoggingConfiguration();

            // Ensure log directory exists
            string logDirectory = @"C:\Logs\MyApp";
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            // Configure file target for logging
            var fileTarget = new FileTarget("logfile")
            {
                FileName = Path.Combine(logDirectory, "logfile-${shortdate}.log"),
                Layout = "${longdate} | ${uppercase:${level}} | ${message} | ${exception:format=ToString,StackTrace}",
                KeepFileOpen = false  // Prevents file locks
               
            };

            // Configure console target for logging to the console
            var consoleTarget = new ConsoleTarget("console")
            {
                Layout = "${longdate} | ${uppercase:${level}} | ${message}"
            };

            // Add the targets to the configuration
            config.AddTarget(fileTarget);
            config.AddTarget(consoleTarget);

            // Define logging rules (Info level and above)
            config.AddRule(LogLevel.Info, LogLevel.Fatal, fileTarget);
            config.AddRule(LogLevel.Info, LogLevel.Fatal, consoleTarget);

            // Apply the configuration
            LogManager.Configuration = config;
        }
    }
}
