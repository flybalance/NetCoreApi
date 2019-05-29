using ServiceStack;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreApi.ServiceStack.ServiceModel.Request
{
    [Api("ServiceStack service类请求")]
    [Route("/service/getcounryinfobyname", Verbs = "POST", Summary = "根据国家名称获取国家信息", Notes = "Notes")]
    public class GetCounryInfoByNameRequest
    {
        [ApiMember(Description = "国家名称", IsRequired = true)]
        public string countryName { get; set; }

        [ApiMember(Description = "国家类型", IsRequired = false)]
        public string countryType { get; set; }
    }
}
