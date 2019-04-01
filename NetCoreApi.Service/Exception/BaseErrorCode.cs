using NetCoreApi.Service.Common.Extention;

namespace NetCoreApi.Service.Exception
{
    public enum BaseErrorCode
    {
        /*********************** 公共错误码10开头 *********************/

        [KeyValueDescription("000000", "处理成功")]
        SUCCESS,

        [KeyValueDescription("100001", "系统异常")]
        FAIL,

        [KeyValueDescription("100002", "请求参数不合法")]
        REQUEST_PARAM_ERROR,

        [KeyValueDescription("100003", "响应参数不合法")]
        RESPONSE_PARAM_ERROR
    }
}