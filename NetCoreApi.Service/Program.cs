using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;

namespace NetCoreApi.Service
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var publishPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var configPath = Path.Combine(publishPath, "wwwroot/Config");
            var config = new ConfigurationBuilder()
                                .SetBasePath(configPath)
                                // 指定服务启动的监听端口
                                .AddJsonFile(Path.Combine(configPath, "hosting.json"), optional: false)
                                .AddJsonFile(Path.Combine(configPath, "appsettings.json"), optional: false, reloadOnChange: true)
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