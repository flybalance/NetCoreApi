using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace NetCoreApi.GetWay
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("configuration.json", optional: false, reloadOnChange: true)
                                .Build();

            var host = new WebHostBuilder()
                              .UseKestrel()
                              .UseConfiguration(config)
                              .UseContentRoot(Directory.GetCurrentDirectory())
                              .UseStartup<Startup>()
                              .Build();

            host.Run();
        }
    }
}