using Elasticsearch.Net;
using Microsoft.Extensions.Options;
using NetCoreApi.Service.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApi.Service.Common.ElasticSearch
{
    public class B2bElasticConnectionPool: SniffingConnectionPool
    {
        public B2bElasticConnectionPool(IOptions<ElasticSearchConfig> options) : base(options.Value.Uris.Select(uri => new Uri(uri)))
        {

        }
    }
}
