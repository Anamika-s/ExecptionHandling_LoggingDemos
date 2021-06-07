using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ExceptionHandling_LoggingDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureLogging((context, logBuilder) =>
            {
                logBuilder.ClearProviders(); // removes all providers from LoggerFactory
                logBuilder.AddConfiguration(context.Configuration.GetSection("Logging"));
                logBuilder.AddDebug();
                logBuilder.AddConsole();
               // logBuilder.AddTraceSource("Information, ActivityTracing");
            })
            .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<StatusCodePagesWithReExecute>();
                  //  webBuilder.UseStartup<StartupUsingStatusCode>();
                    //webBuilder.UseStartup<Startup>();
                    //webBuilder.UseStartup<Startup>();
                });
    }
}
