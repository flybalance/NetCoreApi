using NetCoreApi.ServiceStack.ServiceModel.Response;
using ServiceStack;
using ServiceStack.DataAnnotations;

namespace NetCoreApi.ServiceStack.ServiceModel.Request
{
    /**
     * 标记接口的请求方式
     * 1、 public class HelloWorldRequest : IGet, IReturn<>
     * 2、 [Route("", Verbs = "GET", Summary = "")]
     */
    [Api("ServiceStack service类请求")]
    [Route("/service/first", Verbs = "GET", Summary = "helloworld", Notes = "Notes")]
    public class HelloWorldRequest : IReturn<ApiResponse<string>>
    {
        [ApiMember(Description = "消息内容", IsRequired = true)]
        public string SayHi { get; set; }
    }
}
