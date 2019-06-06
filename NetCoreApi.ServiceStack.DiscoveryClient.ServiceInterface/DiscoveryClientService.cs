using Microsoft.AspNetCore.Mvc;
using NetCoreApi.ServiceStack.ServiceModel.Request;
using NetCoreApi.ServiceStack.ServiceModel.Response;
using ServiceStack;
using System.Net.Http;
using System.Threading.Tasks;

namespace NetCoreApi.ServiceStack.DiscoveryClient.ServiceInterface
{
    public class DiscoveryClientService : BaseService
    {
        private const string url = "http://NetCoreApi.ServiceStack";

        //private readonly DiscoveryHttpClientHandler _handler;
        public DiscoveryClientService()
        {

        }

        //INetApiService client = HttpApiClient.Create<INetApiService>();

        public ApiResponse<string> Get(HelloWorldDiscoveryClientServiceRequest request)
        {
            //var client = GetHttpClient();

            ////string result = await client.GetStringAsync($"{url}/service/first?SayHi=HelloWorldDiscoveryClientServiceRequest");

            //return await apiService.GetHelloWorldApi("=1-1-1-1-1-11-");

            //return result;
            return Gateway.Send(new HelloWorldRequest() { SayHi = "Hello World~~~~" });
            // return null;
        }

        //private HttpClient GetHttpClient()
        //{
        //    var client = new HttpClient(_handler, false);

        //    return client;
        //}
    }
}
