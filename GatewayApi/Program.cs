using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GatewayApi.Aggregators;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace GatewayApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();

            new WebHostBuilder()
               .UseKestrel(options =>
               {
                   options.ListenLocalhost(3000);
               })
               .UseContentRoot(Directory.GetCurrentDirectory())
               .ConfigureAppConfiguration((hostingContext, config) =>
               {
                   config
                       .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                       .AddJsonFile("appsettings.json", true, true)
                       .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
                       .AddJsonFile("ocelot.json")
                       .AddEnvironmentVariables();
               })
               .ConfigureServices(s => {

                   s.AddAuthentication(options =>
                   {
                       options.DefaultScheme = "CustomAuth";
                   });
                   

                   s.AddOcelot()
                   .AddTransientDefinedAggregator<CustomerWithOrdersAggregator>();
               })
               .ConfigureLogging((hostingContext, logging) =>
               {
                    //add your logging
                })
               .UseIISIntegration()
               .Configure(app =>
               {
                   app.UseOcelot().Wait();
               })
               .Build()
               .Run();
        }

        //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)
        //        .UseStartup<Startup>();
    }
}
