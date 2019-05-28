using NetCoreApi.ServiceStack.ServiceModel.Response;
using ServiceStack;

namespace NetCoreApi.ServiceStack.ServiceModel.Request
{
    [Api("ServiceStack 第一个HelloWorld请求")]
    [Route("/helloworld/first", Verbs = "GET", Summary = "GET请求", Notes = "Notes")]
    public class HelloWorldRequest : IReturn<ApiResponse<string>>
    {
        [ApiMember(Description = "消息内容", IsRequired = true)]
        public string SayHi { get; set; }
    }
}
