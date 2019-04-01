using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace NetCoreApi.Service.Domain.Dto
{
    /// <summary>
    /// 省份
    /// </summary>
    [Serializable]
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