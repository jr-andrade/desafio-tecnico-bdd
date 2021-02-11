using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using System;

namespace DesafioLocalizaBdd.Api.Logging
{
    public static class SerilogExtension
    {
        private static readonly LogEventLevel _defaultLogLevel = LogEventLevel.Information;
        private static readonly LoggingLevelSwitch _loggingLevel = new LoggingLevelSwitch();

        private static void LoadLogLevel()
        {
            var configLogLevel = Environment.GetEnvironmentVariable("LOG_LEVEL") ?? _defaultLogLevel.ToString();

            bool parsed = Enum.TryParse(configLogLevel, true, out LogEventLevel logLevel);
            _loggingLevel.MinimumLevel = parsed ? logLevel : _defaultLogLevel;
        }

        private static void ConfigureLog()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .MinimumLevel.ControlledBy(_loggingLevel)
                .CreateLogger();
        }

        public static IServiceCollection AddSerilog(this IServiceCollection services)
        {
            LoadLogLevel();
            ConfigureLog();

            return services;
        }
    }
}
