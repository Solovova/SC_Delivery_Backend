using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using SoloVova.Delivery.Backend.Persistence;

namespace SoloVova.Delivery.Backend.WebApi{
    public class Program{
        public static void Main(string[] args){
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .WriteTo.File("DeliveryWebAppLog-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope()){
                var serviceProvider = scope.ServiceProvider;
                try{
                    var contest = serviceProvider.GetRequiredService<DeliveryDbContext>();
                    DbInitializer.Initialize(contest);
                }
                catch (Exception exception){
                    Log.Fatal(exception, "An error occurred while app initialization");
                }
            }
            
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((cotext, builder) => {
                    
                    builder.AddInMemoryCollection(new Dictionary<string, string>{
                        {"name", "testName"},
                        {"age", "31"}
                    });
                    builder.AddXmlFile("web.config");
                })
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}