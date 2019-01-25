﻿using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCoreApi.Dao;
using NetCoreApi.Dao.Impl;
using NetCoreApi.Domain.Dto.consul;
using NetCoreApi.Service;
using NetCoreApi.Service.Impl;
using Newtonsoft.Json;
using System;

namespace NetCoreApi
{
    /// <summary>
    /// 启动类
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 全局配置
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// 配置项目
        /// </summary>
        /// <param name="services"></param>
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Swagger
            //services.AddSwaggerGen(options =>
            //{
            //    options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
            //    {
            //        Version = "v1",
            //        Title = "API 文档",
            //        Description = "Swagger API Doc"
            //    });

            //    var xmlPath = Path.Combine(AppContext.BaseDirectory, "NetCoreApi.xml");
            //    options.IncludeXmlComments(xmlPath);
            //});

            // AspNetCore.Mvc.Versioning
            //services.AddApiVersioning(o =>
            //{
            //    // 如果设置为true, 在Api请求的响应头部，会追加当前Api支持的版本
            //    o.ReportApiVersions = true;
            //    // 标记当客户端没有指定版本号的时候，是否使用默认版本号
            //    o.AssumeDefaultVersionWhenUnspecified = true;
            //    // 默认版本号
            //    o.DefaultApiVersion = new ApiVersion(1, 0);
            //});

            services.AddSingleton<IStudentDao, StudentDaoImp>();
            services.AddSingleton<IStudentService, StudentServiceImpl>();
        }

        /// <summary>
        /// 注册配置
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime lifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            //app.UseSwagger();
            //app.UseSwaggerUI(options =>
            //{
            //    options.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 Docs");
            //});


            ConsulService consulService = new ConsulService()
            {
                IP = Configuration["Consul:IP"],
                Port = Convert.ToInt32(Configuration["Consul:Port"])
            };

            HealthService healthService = new HealthService()
            {
                IP = Configuration["Service:IP"],
                Port = Convert.ToInt32(Configuration["Service:Port"]),
                Name = Configuration["Service:Name"],
            };


            Console.WriteLine(JsonConvert.SerializeObject(consulService));
            Console.WriteLine(JsonConvert.SerializeObject(healthService));

            app.RegisterConsul(lifetime, healthService, consulService);
        }
    }

    public static class ConsulBuilderExtensions
    {
        // 服务注册
        public static IApplicationBuilder RegisterConsul(this IApplicationBuilder app, IApplicationLifetime lifetime, HealthService healthService, ConsulService consulService)
        {
            //请求注册的 Consul 地址
            var consulClient = new ConsulClient(x => x.Address = new Uri($"http://{consulService.IP}:{consulService.Port}"));
            var httpCheck = new AgentServiceCheck()
            {
                //服务启动多久后注册
                DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),
                //健康检查时间间隔，或者称为心跳间隔
                Interval = TimeSpan.FromSeconds(10),
                //健康检查地址
                HTTP = $"http://{healthService.IP}:{healthService.Port}/api/health",
                Timeout = TimeSpan.FromSeconds(5)
            };

            // Register service with consul
            var registration = new AgentServiceRegistration()
            {
                Checks = new[] { httpCheck },
                ID = healthService.Name + "_" + healthService.Port,
                Name = healthService.Name,
                Address = healthService.IP,
                Port = healthService.Port,

                // 添加 urlprefix-/servicename 格式的 tag 标签，以便 Fabio 识别
                Tags = new[] { $"urlprefix-/{healthService.Name}" }
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