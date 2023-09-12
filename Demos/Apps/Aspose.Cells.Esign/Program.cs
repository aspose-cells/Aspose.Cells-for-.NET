using System;
using System.Globalization;
using Aspose.Cells.Common.Config;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Formatting.Elasticsearch;
using Serilog.Sinks.Elasticsearch;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Aspose.Cells.Esign
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var appId = $"Cells {Startup.AppName}";
            ILogger logger = null;
            try
            {
                var host = CreateHostBuilder(args).Build();
                logger = host.Services.GetService<ILogger<Program>>();
                logger.ApplicationStarting(appId);
                logger.ApplicationVersion(DateTime.Now.ToString(CultureInfo.InvariantCulture));
                logger.ApplicationEnvironment(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));
                host.Run();
                logger.ApplicationShutdown(appId);
            }
            catch (Exception ex)
            {
                logger.ApplicationTerminatedException(appId, ex);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).UseSerilog((context, loggerConfiguration) =>
            {
                loggerConfiguration = loggerConfiguration.ReadFrom.Configuration(context.Configuration);
                loggerConfiguration.WriteTo.Console();
                if (context.HostingEnvironment.IsStaging() || context.HostingEnvironment.IsProduction())
                {
                    loggerConfiguration.MinimumLevel.Warning().WriteTo.Elasticsearch(
                        new ElasticsearchSinkOptions(new Uri(Environment.GetEnvironmentVariable("ES_URL") ?? string.Empty))
                        {
                            IndexFormat = $"cells-{Startup.AppName}-app-{{0:yyyy.MM.dd}}",
                            AutoRegisterTemplate = true,
                            CustomFormatter = new ExceptionAsObjectJsonFormatter(renderMessage: true),
                            FailureCallback = e => Console.WriteLine($@"Unable to submit event {e.MessageTemplate}"),
                            EmitEventFailure = EmitEventFailureHandling.WriteToSelfLog |
                                               EmitEventFailureHandling.RaiseCallback |
                                               EmitEventFailureHandling.ThrowException,
                            ModifyConnectionSettings = x => x.BasicAuthentication(
                                Environment.GetEnvironmentVariable("ES_LOGIN"),
                                Environment.GetEnvironmentVariable("ES_PASSWORD")
                            )
                        }
                    );
                }
            }).ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }
    }
}