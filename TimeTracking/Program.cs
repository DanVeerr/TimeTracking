using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TimeTracking
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //var configuration = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json")
            //    .Build();

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("log-.txt", rollingInterval: RollingInterval.Day)
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                .Enrich.WithClientIp()
                .Enrich.FromLogContext()
                .CreateLogger();

            //    Log.Logger = new LoggerConfiguration()
            //        .MinimumLevel.Information()
            //        .WriteTo.File("log-.txt", rollingInterval: RollingInterval.Day)
            //        .Enrich.FromLogContext()
            //        .CreateBootstrapLogger();
            //Log.Information("Starting up!");
            try
            {
                Log.Information("Starting web host");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                //.UseSerilog((context, services, configuration) => configuration
                //    .ReadFrom.Configuration(context.Configuration.GetSection("Serilog")))
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
