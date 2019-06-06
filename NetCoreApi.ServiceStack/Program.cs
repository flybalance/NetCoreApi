using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using SkyApm.Agent.AspNetCore;

namespace NetCoreApi.ServiceStack
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            var builder = Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseKestrel().
                UseUrls("http://192.168.20.133:5000").
                UseStartup<Startup>();
                //webBuilder.ConfigureServices(services => services.AddSkyAPMCore());
            });

            builder.Build().Run();
        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });
    }
}
