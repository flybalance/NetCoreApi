using NetCoreApi.ServiceStack.ServiceModel.Response;
using ServiceStack;

namespace NetCoreApi.ServiceStack.ServiceModel.Request
{
    [Api("Consul健康检查")]
    [Route("/api/health", Verbs = "GET", Summary = "health", Notes = "health")]
    public class HealthCheckRequest : IReturn<ApiResponse<string>>
    {
    }
}
