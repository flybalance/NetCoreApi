using NetCoreApi.ServiceStack.ServiceModel.Response;
using ServiceStack;
using ServiceStack.DataAnnotations;

namespace NetCoreApi.ServiceStack.ServiceModel.Request
{
    [Api("Consul健康检查")]
    [Route("/api/health", Verbs = "GET", Summary = "health", Notes = "health")]
    // 隐藏接口
    [Exclude(Feature.All)]
    public class HealthCheckRequest : IReturn<ApiResponse<string>>
    {
    }
}
