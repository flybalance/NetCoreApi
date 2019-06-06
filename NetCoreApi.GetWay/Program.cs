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
                              .UseUrls("http://192.168.20.133:8000")
                              .UseConfiguration(config)
                              .UseContentRoot(Directory.GetCurrentDirectory())
                              .UseStartup<Startup>()
                              .Build();

            host.Run();
        }
    }
}