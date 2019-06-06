using NetCoreApi.ServiceStack.ServiceModel.Response;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreApi.ServiceStack.ServiceModel.Request
{
    [Api("DiscoveryClient ServiceStack service类请求")]
    [Route("/disconveryservice/first", Verbs = "GET", Summary = "helloworld", Notes = "Notes")]
    public class HelloWorldDiscoveryClientServiceRequest : IReturn<ApiResponse<string>>
    {
    }
}
