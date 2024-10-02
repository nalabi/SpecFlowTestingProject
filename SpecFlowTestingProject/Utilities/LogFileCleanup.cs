using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowTestingProject.Utilities
{
    public class LogFileCleanup
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

      
        public static void DeleteOldLogFiles(string logDirectory, int daysToKeep)
        {
            try
            {
                
                if (!Directory.Exists(logDirectory))
                {
                    Logger.Warn($"Log directory does not exist: {logDirectory}");
                    return;
                }

              
                var logFiles = Directory.GetFiles(logDirectory, "*.log");

                foreach (var file in logFiles)
                {
                    var fileInfo = new FileInfo(file);

                   
                    if (fileInfo.LastWriteTime < DateTime.Now.AddDays(-daysToKeep))
                    {
                        fileInfo.Delete();
                        Logger.Info($"Deleted old log file: {fileInfo.Name}");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, $"Error during log file cleanup in directory: {logDirectory}");
            }
        }
    }
}
