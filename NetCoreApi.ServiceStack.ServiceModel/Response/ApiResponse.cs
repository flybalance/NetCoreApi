namespace NetCoreApi.ServiceStack.ServiceModel.Response
{
    using NetCoreApi.Common.Utils;
    using System;

    [Serializable]
    public class ApiResponse<T>
    {
        public string Code { get; set; }

        public string Message { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.Now;

        public ApiResult ApiResult { get; set; }

        public T Data { get; set; }

        public ApiResponse<T> Success()
        {
            ApiResult = ApiResult.Success;
            Code = "200";
            Message = "成功";

            return this;
        }

        public ApiResponse<T> Success(T data)
        {
            ApiResult = ApiResult.Success;
            Data = data;

            Code = "200";
            Message = "成功";

            return this;
        }

        public ApiResponse<T> Error()
        {
            ApiResult = ApiResult.Error;

            Code = "000000";
            Message = "失败";

            return this;
        }

        public ApiResponse<T> Error(string message)
        {
            ApiResult = ApiResult.Error;
            Code = "000000";
            Message = message;

            return this;
        }

        public ApiResponse<T> Error(string code, string message)
        {
            ApiResult = ApiResult.Error;
            Code = code;
            Message = message;

            return this;
        }

        public static ApiResponse<T> GetInstance()
        {
            return SingletonUtil<ApiResponse<T>>.GetInstance;
        }
    }

    public enum ApiResult
    {
        /// <summary>
        /// 请求失败
        /// </summary>
        Error,

        /// <summary>
        /// 请求成功
        /// </summary>
        Success
    }
}
