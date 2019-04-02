using NetCoreApi.Service.Common.Extention;

namespace NetCoreApi.Service.Exception.Code
{
    public enum ProvinceErrorCode
    {
        /*********************** 参数基本校验错误码以[20]开头 *********************/

        [KeyValueDescription("200001", "请求实体为空")]
        REQUEST_PARAM_ENTITY_IS_NULL,

        [KeyValueDescription("200002", "省份名称为空")]
        REQUEST_PROVINCE_NAME_IS_EMPTY
    }
}