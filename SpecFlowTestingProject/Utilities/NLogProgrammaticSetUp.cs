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

            
            string logDirectory = @"C:\Logs";
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }
            if (!Directory.Exists(logDirectory))
            {
                
                var fileTarget = new FileTarget("logfile")
                {
                    FileName = Path.Combine(logDirectory, "logfile-${shortdate}.txt"),
                    Layout = "${longdate} | ${uppercase:${level}} | ${message} | ID: ${mdc:item=id} | Tags: ${mdc:item=tags} | Start Time: ${date:format=MM/dd/yyyy hh:mm:ss tt}",
                    KeepFileOpen = false  
                };

                // Setup a console target to output logs to the console
                var consoleTarget = new ConsoleTarget("console")
                {
                    Layout = "${longdate} | ${uppercase:${level}} | ${message} | ID: ${mdc:item=id} | Tags: ${mdc:item=tags} | Start Time: ${date:format=MM/dd/yyyy hh:mm:ss tt}"
                };

                // Add the targets to the configuration
                config.AddTarget(fileTarget);
                config.AddTarget(consoleTarget);

                // Define rules to log messages of level Info or higher to both the file and the console
                config.AddRule(LogLevel.Info, LogLevel.Fatal, fileTarget);  // Log to file from Info level to Fatal
                config.AddRule(LogLevel.Info, LogLevel.Fatal, consoleTarget);  // Log to console from Info level to Fatal

                // Apply the configuration to NLog
                LogManager.Configuration = config;
            }
        }
    }
}
