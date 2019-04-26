using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApi.Service.Common.Cache
{
    public interface ICacheService<T>
    {
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">缓存key</param>
        /// <returns></returns>
        T Get(string key);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetString(string key);

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">缓存key</param>
        /// <param name="value">缓存值</param>
        /// <param name="ExpirationTime">绝对过期时间(分钟)</param>
        void Add(string key, string value, int? ExpirationTime = 1);

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key"></param>
        void Remove(string key);
    }
}
