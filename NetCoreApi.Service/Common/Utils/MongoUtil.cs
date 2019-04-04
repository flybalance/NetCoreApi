using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace NetCoreApi.Service.Common.Utils
{
    public class MongoUtil<T> where T : new()
    {
        private static IMongoDatabase mongoDatabase = null;

        private static IMongoCollection<T> mongoCollection = null;

        private static readonly object lockHelper = new object();

        public static IMongoCollection<T> GetMongoCollection(string collectionName, IConfiguration configuration)
        {
            if (null == mongoCollection)
            {
                lock (lockHelper)
                {
                    if (null == mongoCollection)
                    {
                        mongoDatabase = new MongoDb(configuration).GetMongoDatabase;
                        mongoCollection = mongoDatabase.GetCollection<T>(string.IsNullOrEmpty(collectionName) ? typeof(T).Name : collectionName);
                    }
                }
            }

            return mongoCollection;
        }
    }

    public class MongoDb
    {
        private static IConfiguration _configuration;

        public MongoDb(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private static IMongoDatabase mongoDatabase = null;

        private static readonly object lockHelper = new object();

        /// <summary>
        /// 创建mongodb连接
        /// </summary>
        public IMongoDatabase GetMongoDatabase
        {
            get
            {
                if (null == mongoDatabase)
                {
                    lock (lockHelper)
                    {
                        if (null == mongoDatabase)
                        {
                            var client = new MongoClient(_configuration["Mongo:Uri"]);
                            mongoDatabase = client.GetDatabase(_configuration["Mongo:DbName"]);
                        }
                    }
                }

                return mongoDatabase;
            }
        }
    }
}