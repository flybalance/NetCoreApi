using MongoDB.Driver;

namespace NetCoreApi.Service.Common.Utils
{
    public class MongoUtil<T> where T : new()
    {
        private static IMongoDatabase mongoDatabase = null;

        private static IMongoCollection<T> mongoCollection = null;

        private static readonly object lockHelper = new object();

        public static IMongoCollection<T> GetMongoCollection(string collectionName = "")
        {
            if (null == mongoCollection)
            {
                lock (lockHelper)
                {
                    if (null == mongoCollection)
                    {
                        mongoDatabase = MongoDb.GetMongoDatabase;
                        mongoCollection = mongoDatabase.GetCollection<T>(string.IsNullOrEmpty(collectionName) ? typeof(T).Name : collectionName);
                    }
                }
            }

            return mongoCollection;
        }
    }

    public class MongoDb
    {
        private static readonly string CONNECTION_STRING = "mongodb://192.168.20.133:27017";

        private static readonly string MONGO_DB_NAME = "netcore";

        private static IMongoDatabase mongoDatabase = null;

        private static readonly object lockHelper = new object();

        /// <summary>
        /// 创建mongodb连接
        /// </summary>
        public static IMongoDatabase GetMongoDatabase
        {
            get
            {
                if (null == mongoDatabase)
                {
                    lock (lockHelper)
                    {
                        if (null == mongoDatabase)
                        {
                            var client = new MongoClient(CONNECTION_STRING);
                            mongoDatabase = client.GetDatabase(MONGO_DB_NAME);
                        }
                    }
                }

                return mongoDatabase;
            }
        }
    }
}