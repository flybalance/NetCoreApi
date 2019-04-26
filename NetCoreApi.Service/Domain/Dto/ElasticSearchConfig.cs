
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace NetCoreApi.Service.Domain.Dto
{
    public class ElasticSearchConfig
    {
        public IEnumerable<string> Uris { get; set; }

        public string DefaultIndex { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
