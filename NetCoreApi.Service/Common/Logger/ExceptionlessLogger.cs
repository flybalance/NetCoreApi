using Exceptionless;
using Exceptionless.Logging;

namespace NetCoreApi.Service.Common.Logger
{
    public class ExceptionlessLogger : ILoggerHelper
    {
        public void Debug(string source, string message, params string[] args)
        {
            if (null != args && args.Length > 0)
            {
                ExceptionlessClient.Default.CreateLog(source, message, LogLevel.Debug).AddTags(args).Submit();
            }
            else
            {
                ExceptionlessClient.Default.SubmitLog(source, message, LogLevel.Debug);
            }
        }

        public void Error(string source, string message, params string[] args)
        {
            if (null != args && args.Length > 0)
            {
                ExceptionlessClient.Default.CreateLog(source, message, LogLevel.Error).AddTags(args).Submit();
            }
            else
            {
                ExceptionlessClient.Default.SubmitLog(source, message, LogLevel.Error);
            }
        }

        public void Info(string source, string message, params string[] args)
        {
            if (null != args && args.Length > 0)
            {
                ExceptionlessClient.Default.CreateLog(source, message, LogLevel.Info).AddTags(args).Submit();
            }
            else
            {
                ExceptionlessClient.Default.SubmitLog(source, message, LogLevel.Info);
            }
        }

        public void Trace(string source, string message, params string[] args)
        {
            if (null != args && args.Length > 0)
            {
                ExceptionlessClient.Default.CreateLog(source, message, LogLevel.Trace).AddTags(args).Submit();
            }
            else
            {
                ExceptionlessClient.Default.SubmitLog(source, message, LogLevel.Trace);
            }
        }

        public void Warn(string source, string message, params string[] args)
        {
            if (null != args && args.Length > 0)
            {
                ExceptionlessClient.Default.CreateLog(source, message, LogLevel.Warn).AddTags(args).Submit();
            }
            else
            {
                ExceptionlessClient.Default.SubmitLog(source, message, LogLevel.Warn);
            }
        }
    }
}