using NetCoreApi.Common.Extention;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApi.Exception.Code
{
    public enum StudentErrorCode
    {
        /*********************** 参数基本校验错误码以[20]开头 *********************/
        [KeyValueDescription("200001", "请求实体为空")]
        REQUEST_PARAM_ENTITY_IS_NULL
    }
}
