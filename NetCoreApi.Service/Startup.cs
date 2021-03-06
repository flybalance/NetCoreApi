﻿using Autofac;
using Autofac.Extensions.DependencyInjection;
using Consul;
using Elasticsearch.Net;
using Exceptionless;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using NetCoreApi.Service.Common.ElasticSearch;
using NetCoreApi.Service.Common.Filter;
using NetCoreApi.Service.Common.Interface;
using NetCoreApi.Service.Common.Swagger;
using NetCoreApi.Service.Domain.Dto;
using NetCoreApi.Service.Domain.Dto.consul;
using SmartSql.ConfigBuilder;
using System;
using System.IO;
using System.Reflection;

namespace NetCoreApi.Service
{
    /// <summary>
    /// 启动类
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 全局配置
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// 配置项目
        /// </summary>
        /// <param name="services"></param>
        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //services.AddOptions();
            services.AddMvc(options =>
            {
                // 配置全局过滤器
                options.Filters.Add<GlobalExceptionFilter>();
            });

            // 使用Newtonsoft.Json托管系统json处理类
            //services.AddMvc().AddJsonOptions(options =>
            //    options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver()).
            //    SetCompatibilityVersion(CompatibilityVersion.Latest);

            // SmartSql配置
            services.AddSmartSql(options =>
            {
                var publishPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                var configPath = Path.Combine(publishPath, "wwwroot/Config");

                // 定义实例别名，在多库场景下适用
                options.UseAlias("SmartSqlSampleChapterOne")
                .UseXmlConfig(ResourceType.File, configPath + "\\SmartSqlMapConfig.xml");
            });

            // 路由配置为小写
            services.AddRouting(options => options.LowercaseUrls = true);

            services.Configure<ElasticSearchConfig>(_configuration.GetSection("elasticSearch"));
            services.AddSingleton<IConnectionPool, B2bElasticConnectionPool>();
            services.AddScoped<IElasticClient, B2bElasticClient>();

            // Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Version = "v1",
                    Title = "NetCore Swagger API 文档",
                    Description = "NetCore Swagger  API Doc"
                });

                //添加对控制器的标签(描述)
                options.DocumentFilter<ApplyTagDescription>();

                string xmlPath = Path.Combine(AppContext.BaseDirectory, "NetCoreApi.Service.xml");
                options.IncludeXmlComments(xmlPath);
            });

            //AspNetCore.Mvc.Versioning
            //services.AddApiVersioning(o =>
            //{
            //    // 如果设置为true, 在Api请求的响应头部，会追加当前Api支持的版本
            //    o.ReportApiVersions = true;
            //    // 标记当客户端没有指定版本号的时候，是否使用默认版本号
            //    o.AssumeDefaultVersionWhenUnspecified = true;
            //    // 默认版本号
            //    o.DefaultApiVersion = new ApiVersion(1, 0);
            //});

            // 实例化 AutoFac  容器
            var builder = new ContainerBuilder();

            // NetCoreApi是继承接口的实现方法类库名称
            var assemblys = Assembly.Load("NetCoreApi.Service");
            // IDependency 是一个接口（所有要实现依赖注入的借口都要继承该接口）
            var baseType = typeof(IDependency);
            builder.RegisterAssemblyTypes(assemblys)
                              .Where(m => baseType.IsAssignableFrom(m) && m != baseType)
                              .AsImplementedInterfaces().SingleInstance();

            builder.Populate(services);

            // 第三方IOC接管 core内置DI容器
            return new AutofacServiceProvider(builder.Build());
        }

        /// <summary>
        /// 注册配置
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// /// <param name="lifeTime"></param>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime lifeTime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseStaticFiles();
            //app.UseApiVersioning();

            // exceptionless
            //ExceptionlessClient.Default.Configuration.ApiKey = Configuration["Exceptionless:ApiKey"];
            //ExceptionlessClient.Default.Configuration.ServerUrl = Configuration["Exceptionless:ServerUrl"];
            ExceptionlessClient.Default.SubmittingEvent += OnSubmittingEvent;
            app.UseExceptionless(_configuration);

            // swagger
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 Docs");
            });

            ConsulService consulService = new ConsulService()
            {
                IP = _configuration["Consul:IP"],
                Port = Convert.ToInt32(_configuration["Consul:Port"])
            };

            HealthService healthService = new HealthService()
            {
                IP = _configuration["Service:IP"],
                Port = Convert.ToInt32(_configuration["Service:Port"]),
                Name = _configuration["Service:Name"],
            };

            //app.RegisterConsul(lifeTime, healthService, consulService);
        }

        /// <summary>
        /// 全局配置Exceptionless
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSubmittingEvent(object sender, EventSubmittingEventArgs e)
        {
            //// 忽略已处理的异常
            //if (!e.IsUnhandledError)
            //{
            //    return;
            //}

            // 忽略404错误
            if (e.Event.IsNotFound())
            {
                e.Cancel = true;
                return;
            }

            // 忽略没有错误体的错误
            if (null == e.Event.GetError())
            {
                return;
            }

            e.Event.MarkAsCritical();
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