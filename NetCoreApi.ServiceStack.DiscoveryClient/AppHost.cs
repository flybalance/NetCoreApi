using Funq;
using NetCoreApi.ServiceStack.DiscoveryClient.ServiceInterface;
using ServiceStack;
using ServiceStack.Api.Swagger;
using ServiceStack.Discovery.Consul;
using ServiceStack.Web;
using System;
using System.Collections.Generic;

namespace NetCoreApi.ServiceStack.DiscoveryClient
{
    public class AppHost : AppHostBase
    {
        public AppHost() : base("NetCoreApi.ServiceStack.DiscoveryClient", typeof(BaseService).Assembly)
        {
        }

        public override void Configure(Container container)
        {
            ConsulSettings consulSettings = new ConsulSettings(settings =>
            {
                settings.ConsulAgentUrl = "http://192.168.200.235:8500";
                settings.IncludeDefaultServiceHealth = false;
                settings.SetDefaultGateway(baseUri => new JsonServiceClient(baseUri) { UserName = "NetCoreApi.ServiceStack" });
                settings.AddTags("urlprefix-/NetCoreApi.ServiceStack");
                //settings.AddServiceCheck(host =>
                //{
                //    return new HealthCheck(ServiceHealth.Ok, "working normally");
                //},
                //// default check once per minute
                //intervalInSeconds: 60,
                //// deregisters the service if health is critical after x minutes, null = disabled by default
                //deregisterIfCriticalAfterInMinutes: 30
                //);
            });

            var appHost = new HostConfig
            {
                // 禁用Metadata Soap11 Soap12页面
                EnableFeatures = Feature.All.Remove(Feature.Metadata | Feature.Soap11 | Feature.Soap12),
                // 修改默认的metadata页面未swagger-ui页面
                DefaultRedirectPath = "/swagger-ui/",
                // 禁用调试模式
                DebugMode = true,

                // the url:port that other services will use to access this one
                //WebHostUrl = "http://192.168.20.133:5123",

                // optional
                //ApiVersion = "1.0",
                HandlerFactoryPath = "/"
            };

            SetConfig(appHost);
            Plugins.Add(new ConsulFeature(consulSettings));
            // 启用swagger插件
            Plugins.Add(new SwaggerFeature());

            // 未捕获的异常在此处统一处理
            UncaughtExceptionHandlers.Add(UncaughtExceptionHandlersDel);
        }

        private void UncaughtExceptionHandlersDel(IRequest httpRequest, IResponse httpResponse,
            string operationName, Exception exception)
        {
            // Exceptionless 异常记录
        }
    }
}
