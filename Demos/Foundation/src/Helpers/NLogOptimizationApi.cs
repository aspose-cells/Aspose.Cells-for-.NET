using NLog;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Tools.Foundation.Services;

namespace Tools.Foundation.Helpers
{
    [Target("OptimizationApi")]
    public sealed class NLogOptimizationApi : AsyncTaskTarget
    {
        static LogService _LogService = new LogService();
#if DEBUG
        internal static List<(DateTime sent, Models.DTO.LoggingApi.Log log, int? id, Exception ex)?> sentLogs = new List<(DateTime sent, Models.DTO.LoggingApi.Log log, int? id, Exception ex)?>();
#endif

        public NLogOptimizationApi()
        {
            //this.IncludeEventProperties = true; // Include LogEvent Properties by default
            //this.Host = "localhost";
        }

        //[RequiredParameter]
        //public string Host { get; set; }

        protected override async Task WriteAsyncTask(LogEventInfo logEvent, CancellationToken token)
        {
            //IDictionary<string, object> logProperties = this.GetAllProperties(logEvent);			
            string getPropertyOrNull(string key) =>
                logEvent.Properties.ContainsKey(key)
                    ? $"{logEvent.Properties[key]}"
                    : null;

            var log = new Models.DTO.LoggingApi.Log
            {
                Level = $"{logEvent.Level}",
                Callsite = $"{logEvent.CallerClassName}.{logEvent.CallerMemberName}",
                Type = $"{logEvent.Exception?.GetType()}",
                Message = logEvent.Exception?.Message,
                Stacktrace = logEvent.Exception?.StackTrace,
                InnerException = logEvent.Exception?.InnerException?.ToString(),
                AdditionalInfo = logEvent.Message,
                Product = getPropertyOrNull("product"),
                Productfamily = getPropertyOrNull("productfamily"),
                Filename = getPropertyOrNull("filename")
            };
#if DEBUG
            int? id = null;
            Exception ex = null;
            try
            {
                id = await _LogService.SendLog(log);
            }
            catch (Exception e)
            {
                ex = e;
                throw;
            }
            finally
            {
                lock (sentLogs)
                    sentLogs.Add((DateTime.UtcNow, log, id, ex));
            }
#else
			await _LogService.SendLog(log);
#endif
        }
    }
}