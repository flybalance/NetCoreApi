using Elasticsearch.Net;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApi.Service.Common.ElasticSearch
{
    public class B2bElasticClient: ElasticClient
    {
        public B2bElasticClient(IConnectionPool pool) : base(new ConnectionSettings(pool).EnableDebugMode().PrettyJson())
        {

        }
    }
}
