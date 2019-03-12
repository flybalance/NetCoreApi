using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApi.Domain.Dto
{
    /// <summary>
    /// 省份
    /// </summary>
    public class Province
    {
        /// <summary>
        /// 省份id
        /// </summary>
        [BsonId]
        public long ProvinceId { get; set; }

        /// <summary>
        /// 省份名
        /// </summary>
        public string ProvinceName { get; set; }

        /// <summary>
        /// 学校
        /// </summary>
        public IList<School> School { get; set; }
    }
}
