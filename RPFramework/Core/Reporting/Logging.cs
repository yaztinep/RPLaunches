﻿using RPFramework.Core.Config;
using Serilog;
using Serilog.Core;

namespace RPFramework.Core.Reporting
{
    internal class Logging
    {
        LoggingLevelSwitch _loggingLevelSwitch;
        IDefaultVariables _idefaultVariables;
        public Logging(IDefaultVariables idefaultVariables)
        {
            _idefaultVariables = idefaultVariables;
            _loggingLevelSwitch = new LoggingLevelSwitch(Serilog.Events.LogEventLevel.Debug);
            Log.Logger = new LoggerConfiguration().MinimumLevel.ControlledBy(_loggingLevelSwitch)
                .WriteTo.Map("{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:1j}{NewLine}{Exception}",
                (name, wt) => wt.File(_idefaultVariables.Log))
                .CreateLogger();
        }

        public void SetLogLevel(string loglevel)
        {
            switch (loglevel.ToLower())
            {
                case "debug":
                    _loggingLevelSwitch.MinimumLevel = Serilog.Events.LogEventLevel.Debug;
                    break;
                case "error":
                    _loggingLevelSwitch.MinimumLevel = Serilog.Events.LogEventLevel.Error;
                    break;
                case "information":
                    _loggingLevelSwitch.MinimumLevel = Serilog.Events.LogEventLevel.Information;
                    break;
                case "fatal":
                    _loggingLevelSwitch.MinimumLevel = Serilog.Events.LogEventLevel.Fatal;
                    break;
                default:
                    _loggingLevelSwitch.MinimumLevel = Serilog.Events.LogEventLevel.Debug;
                    break;
            }
        }

        public void Debug(string message)
        {
            Log.Logger.Debug(message);
        }

        public void Error(string message)
        {
            Log.Logger.Error(message);
        }

        public void Warning(string message)
        {
            Log.Logger.Warning(message);
        }

        public void Information(string message)
        {
            Log.Logger.Information(message);
        }
    }
}
