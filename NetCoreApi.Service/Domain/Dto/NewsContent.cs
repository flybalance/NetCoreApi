using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApi.Service.Domain.Dto
{
    /// <summary>
    /// ElasticsearchType的Name属性值大小写要与ES保持一致
    /// </summary>
    [ElasticsearchType(Name= "NewsContent")]
    [Serializable]
    public class NewsContent
    {
        public string Title { get; set; }

        public string Source { get; set; }

        public long ShowTime { get; set; }

        public string Url { get; set; }

        public string Content { get; set; }

        public string CopyRight { get; set; }

        public string CreateUserName { get; set; }
    }
}
