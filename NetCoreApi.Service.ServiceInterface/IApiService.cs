using NetCoreApi.ServiceStack.ServiceModel.Request;
using NetCoreApi.ServiceStack.ServiceModel.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreApi.ServiceStack.ServiceInterface
{
    public interface IApiService
    {
        Task<ApiResponse<string>> Get(HelloWorldRequest request);

        Task<ApiResponse<string>> Post(GetCounryInfoByNameRequest request);

        Task<ApiResponse<string>> Get(HealthCheckRequest request);
    }
}
