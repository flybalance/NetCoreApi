using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApi.Service.Domain.Dto
{
    public class DetailUser
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public int UserLevel { get; set; }

        public long CreateTime { get; set; }
    }
}
