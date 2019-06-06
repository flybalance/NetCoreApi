using NetCoreApi.ServiceStack.ServiceModel.Request;
using NetCoreApi.ServiceStack.ServiceModel.Response;
using System;
using System.Threading.Tasks;

namespace NetCoreApi.ServiceStack.ServiceInterface.Impl
{
    public class ApiService : BaseService, IApiService
    {
        /// <summary>
        /// HelloWorld 请求方法
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ApiResponse<string>> Get(HelloWorldRequest request)
        {
            ApiResponse<string> apiResponse = ApiResponse<string>.GetInstance();
            if (null == request || string.IsNullOrEmpty(request.SayHi))
            {
                return await Task.FromResult(apiResponse.Error());
            }

            try
            {
                string sayHi = $"消息内容为--{request.SayHi}";
                apiResponse.Success(sayHi);
            }
            catch (Exception)
            {
                throw;
            }

            return await Task.FromResult(apiResponse);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ApiResponse<string>> Post(GetCounryInfoByNameRequest request)
        {
            ApiResponse<string> apiResponse = ApiResponse<string>.GetInstance();
            if (null == request || string.IsNullOrEmpty(request.countryName))
            {
                return await Task.FromResult(apiResponse.Error());
            }

            try
            {
                string sayHi = $"国家名称--{request.countryName}";
                apiResponse.Success(sayHi);
            }
            catch (Exception)
            {
                throw;
            }

            return await Task.FromResult(apiResponse);
        }

        public async Task<ApiResponse<string>> Get(HealthCheckRequest request)
        {
            ApiResponse<string> apiResponse = ApiResponse<string>.GetInstance();

            apiResponse.Success();

            return await Task.FromResult(apiResponse);
        }
    }
}
