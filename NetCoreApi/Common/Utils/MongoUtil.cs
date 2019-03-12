using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApi.Common.Utils
{
    public class MongoUtil
    {
        public static MongoClient GetMongoClient()
        {
            return SingletonUtil<MongoClient>.GetInstance;
        }
    }
}
