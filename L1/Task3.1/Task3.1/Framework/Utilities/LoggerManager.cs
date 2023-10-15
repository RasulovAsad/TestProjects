using Serilog.Core;
using Serilog.Events;
using Serilog;

namespace Task3._1.Framework.Utilities
{
    public class LoggerManager
    {
        private static string _logsPath = Path.Combine(Directory.GetParent(@"..\..\..\").FullName, @"Logs\log.log");

        public static void LoggerInit()
        {
            LoggingLevelSwitch levelSwitch = new LoggingLevelSwitch(LogEventLevel.Debug);
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.ControlledBy(levelSwitch)
                .WriteTo.File(_logsPath,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} | {Level:u3} | {Message} {NewLine}",
                rollingInterval: RollingInterval.Hour).CreateLogger();
        }
    }
}
