using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NetCoreApi.Service.Common.Logger;
using NetCoreApi.Service.Domain.Response;
using Newtonsoft.Json;
using System;
using System.Net;

namespace NetCoreApi.Service.Common.Filter
{
    /// <summary>
    /// 全局异常过滤器
    /// 所有异常全部抛出，不做处理，并在此处捕获并记录
    /// </summary>
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILoggerHelper _loggerHelper;

        public GlobalExceptionFilter(ILoggerHelper loggerHelper)
        {
            _loggerHelper = loggerHelper;
        }

        public void OnException(ExceptionContext context)
        {
            string errorMessage = "请求参数：" + Environment.NewLine + JsonConvert.SerializeObject(context.RouteData?.Values);
            errorMessage += Environment.NewLine + "错误信息：" + context.Exception?.ToString();
            _loggerHelper.Error(context.Exception?.TargetSite.GetType().FullName, errorMessage, context.Exception?.GetType().FullName);

            ApiResponse<string> apiResponse = ApiResponse<string>.GetInstance();
            apiResponse.Error(context.Exception?.Message);

            context.Result = new ObjectResult(apiResponse);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
            context.ExceptionHandled = true;
        }
    }
}