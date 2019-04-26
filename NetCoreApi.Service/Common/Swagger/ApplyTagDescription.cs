using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApi.Service.Common.Swagger
{
    public class ApplyTagDescription : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Tags = new List<Tag>
            {
                // 添加对应的控制器描述 这个是好不容易在issues里面翻到的
                new Tag { Name = "NewsContent", Description = "新闻信息(ElasticSearch)" }
            };
        }
    }
}
