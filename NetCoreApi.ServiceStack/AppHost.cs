using Funq;
using NetCoreApi.ServiceStack.ServiceInterface;
using ServiceStack;
using ServiceStack.Api.Swagger;
using ServiceStack.Auth;
using ServiceStack.Web;
using System;
using System.Collections.Generic;

namespace NetCoreApi.ServiceStack
{
    public class AppHost : AppHostBase
    {
        public AppHost() : base("NetCoreApi.ServiceStack", typeof(BaseService).Assembly)
        {
        }

        public override void Configure(Container container)
        {
            // 启用swagger插件
            Plugins.Add(new SwaggerFeature());

            var appHost = new HostConfig
            {
                // 禁用Metadata Soap11 Soap12页面
                EnableFeatures = Feature.All.Remove(Feature.Metadata | Feature.Soap11 | Feature.Soap12),
                // 修改默认的metadata页面未swagger-ui页面
                DefaultRedirectPath = "/swagger-ui/",
                // 禁用调试模式
                DebugMode = true,
            };

            SetConfig(appHost);

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
