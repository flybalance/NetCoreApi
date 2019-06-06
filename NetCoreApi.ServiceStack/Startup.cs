using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceStack;
using Steeltoe.Discovery.Client;
using System;

namespace NetCoreApi.ServiceStack
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDiscoveryClient(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime lifeTime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var appHost = new AppHost
            {
                AppSettings = new NetCoreAppSettings(Configuration)
            };

            app.UseServiceStack(appHost);

            //app.UseDiscoveryClient();

            app.RegisterConsul(lifeTime);
        }
    }

    public static class ConsulBuilderExtensions
    {
        // 服务注册
        public static IApplicationBuilder RegisterConsul(this IApplicationBuilder app, IApplicationLifetime lifetime)
        {
            //请求注册的 Consul 地址
            var consulClient = new ConsulClient(x => x.Address = new Uri("http://192.168.200.233:8500"));
            var httpCheck = new AgentServiceCheck()
            {
                //服务启动多久后注册
                DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),
                //健康检查时间间隔，或者称为心跳间隔
                Interval = TimeSpan.FromSeconds(10),
                //健康检查地址
                HTTP = "http://192.168.20.133:5000/api/health?format=json",
                Timeout = TimeSpan.FromSeconds(5)
            };

            // Register service with consul
            var registration = new AgentServiceRegistration()
            {
                Checks = new[] { httpCheck },
                ID = "NetCoreApi.ServiceStack" + "_" + "5000",
                Name = "NetCoreApi.ServiceStack",
                Address = "192.168.20.133",
                Port = 5000,

                // 添加 urlprefix-/servicename 格式的 tag 标签，以便 Fabio 识别
                Tags = new[] { "urlprefix-/NetCoreApi.ServiceStack" }
            };

            // 服务启动时注册，内部实现其实就是使用 Consul API 进行注册（HttpClient发起）
            consulClient.Agent.ServiceRegister(registration).Wait();

            lifetime.ApplicationStopping.Register(() =>
            {
                // 服务停止时取消注册
                consulClient.Agent.ServiceDeregister(registration.ID).Wait();
            });

            return app;
        }
    }
}
