using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace RestAPITesting.Logging
{
    public static class LoggerManager
    {
        private static string logsPath = Path.Combine(Environment.CurrentDirectory, @"Logs\log.log");

        public static void LoggerInit()
        {
            LoggingLevelSwitch levelSwitch = new LoggingLevelSwitch(LogEventLevel.Debug);
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.ControlledBy(levelSwitch)
                .WriteTo.File(logsPath,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} | {Level:u3} | {Message} {NewLine}",
                rollingInterval: RollingInterval.Infinite).CreateLogger();
        }
    }
}
