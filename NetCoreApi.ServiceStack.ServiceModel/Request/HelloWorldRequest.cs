using NetCoreApi.ServiceStack.ServiceModel.Response;
using ServiceStack;

namespace NetCoreApi.ServiceStack.ServiceModel.Request
{
    [Api("ServiceStack service类请求")]
    [Route("/service/first", Verbs = "GET", Summary = "helloworld", Notes = "Notes")]
    public class HelloWorldRequest : IReturn<ApiResponse<string>>
    {
        [ApiMember(Description = "消息内容", IsRequired = true)]
        public string SayHi { get; set; }
    }
}
