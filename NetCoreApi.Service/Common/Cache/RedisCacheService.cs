//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace NetCoreApi.Service.Common.Cache
//{
//    public class RedisCacheService<T> : ICacheService<T>
//    {
//        private RedisCache _redisCache = null;
//        public RedisCacheService(RedisCacheOptions options)
//        {
//            _redisCache = new RedisCache(options);
//        }

//        public void Add(string key, string value, int? ExpirationTime = 1)
//        {
//            throw new NotImplementedException();
//        }

//        public T Get(string key)
//        {
//            throw new NotImplementedException();
//        }

//        public string GetString(string key)
//        {
//            throw new NotImplementedException();
//        }

//        public void Remove(string key)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
