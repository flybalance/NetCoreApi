using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace NetCoreApi
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                // 指定服务启动的监听端口
                                .AddJsonFile("hosting.json", optional: true)
                                .AddJsonFile("appsettings.json", optional: true)
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