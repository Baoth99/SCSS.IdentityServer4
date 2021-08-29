﻿using Microsoft.Extensions.DependencyInjection;
using NLog;
using NLog.AWS.Logger;
using NLog.Config;
using NLog.Targets;
using SCSS.IdentityServer4.Services.Implementations;
using SCSS.IdentityServer4.Services.Interfaces;
using SCSS.Utilities.Configurations;
using SCSS.Utilities.Helper;
using System;

namespace SCSS.IdentityServer4.SystemConfigurations
{
    internal static class LoggingSetUp
    {
        public static void AddLoggingSetUp(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentException(nameof(services));
            }

            // Load nlog.config file
            var config = new LoggingConfiguration(LogManager.LoadConfiguration(FileHelper.GetFileConfig(AppSettingValues.LoggingConfig)));

            if (ConfigurationHelper.IsProduction || ConfigurationHelper.IsTesting)
            {
                // Config NLog in order to connect to AWS WatchCloud
                var awsTarget = new AWSTarget()
                {
                    LogGroup = AppSettingValues.AWSCloudWatchLogGroup,
                    LogStreamNamePrefix = "SCSS",
                    Region = AppSettingValues.AWSRegion,
                    Credentials = new Amazon.Runtime.BasicAWSCredentials(AppSettingValues.AWSCloudWatchAccessKey, AppSettingValues.AWSCloudWatchSecrectKey)
                };
                config.AddTarget("aws", awsTarget);
                config.LoggingRules.Add(new LoggingRule("*", LogLevel.Info, awsTarget));
            }

            if (ConfigurationHelper.IsDevelopment)
            {
                var logTarget = new ConsoleTarget();
                config.AddTarget("console", logTarget);
                config.AddRule(LogLevel.Info, LogLevel.Fatal, logTarget);
            }

            LogManager.Configuration = config;

            // Logging
            services.AddSingleton<ILoggerService, LoggerService>();
        }
    }
}
