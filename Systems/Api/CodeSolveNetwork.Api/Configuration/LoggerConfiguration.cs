using CodeSolveNetwork.Services.Settings.Settings;
using Serilog;
using Serilog.Events;

namespace CodeSolveNetwork.Api.Configuration
{
    /// <summary>
/// Logger Configuration
/// </summary>
public static class LoggerConfiguration
{
    /// <summary>
    /// Add logger
    /// </summary>
    public static void AddAppLogger(this WebApplicationBuilder builder, MainSettings mainSettings,
        LogSettings logSettings)
    {
        var loggerConfiguration = new Serilog.LoggerConfiguration();

        // Base configuration
        loggerConfiguration
            .Enrich.WithCorrelationIdHeader()
            .Enrich.FromLogContext();

        // Log level
        if (!Enum.TryParse(logSettings.Level, out Services.Settings.Settings.LogLevel level)) level = Services.Settings.Settings.LogLevel.Information;

        ;

        var serilogLevel = level switch
        {
            Services.Settings.Settings.LogLevel.Verbose => LogEventLevel.Verbose,
            Services.Settings.Settings.LogLevel.Debug => LogEventLevel.Debug,
            Services.Settings.Settings.LogLevel.Information => LogEventLevel.Information,
            Services.Settings.Settings.LogLevel.Warning => LogEventLevel.Warning,
            Services.Settings.Settings.LogLevel.Error => LogEventLevel.Error,
            Services.Settings.Settings.LogLevel.Fatal => LogEventLevel.Fatal,
            _ => LogEventLevel.Information
        };

        loggerConfiguration
            .MinimumLevel.Is(serilogLevel)
            .MinimumLevel.Override("Microsoft", serilogLevel)
            .MinimumLevel.Override("Microsoft.AspNetCore.Mvc", serilogLevel)
            .MinimumLevel.Override("System", serilogLevel)
            ;

        // Writers
        var logItemTemplate =
            "[{Timestamp:HH:mm:ss:fff} {Level:u3} ({CorrelationId})] {Message:lj}{NewLine}{Exception}";

        // Writing to Console configuration 
        if (logSettings.WriteToConsole)
            loggerConfiguration.WriteTo.Console(
                serilogLevel,
                logItemTemplate
            );

        // Writing to File configuration 
        if (logSettings.WriteToFile)
        {
            if (!Enum.TryParse(logSettings.FileRollingInterval, out LogRollingInterval interval))
                interval = LogRollingInterval.Day;

            ;

            var serilogInterval = interval switch
            {
                LogRollingInterval.Infinite => RollingInterval.Infinite,
                LogRollingInterval.Year => RollingInterval.Year,
                LogRollingInterval.Month => RollingInterval.Month,
                LogRollingInterval.Day => RollingInterval.Day,
                LogRollingInterval.Hour => RollingInterval.Hour,
                LogRollingInterval.Minute => RollingInterval.Minute,
                _ => RollingInterval.Day
            };


            if (!int.TryParse(logSettings.FileRollingSize, out var size)) size = 5242880;

            ;

            var fileName =
                $"_.log";

            loggerConfiguration.WriteTo.File($"logs/{fileName}",
                serilogLevel,
                logItemTemplate,
                rollingInterval: serilogInterval,
                rollOnFileSizeLimit: true,
                fileSizeLimitBytes: size
            );
        }

        // Make logger
        var logger = loggerConfiguration.CreateLogger();


        // Apply logger to application
        builder.Host.UseSerilog(logger, true);
    }
}
}
