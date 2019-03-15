using NetCoreApi.Common.Extention;

namespace NetCoreApi.Exception.Code
{
    public enum ProvinceErrorCode
    {
        /*********************** 参数基本校验错误码以[20]开头 *********************/

        [KeyValueDescription("200001", "请求实体为空")]
        REQUEST_PARAM_ENTITY_IS_NULL
    }
}