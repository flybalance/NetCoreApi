using MongoDB.Driver;
using NetCoreApi.Domain.Dto;

namespace NetCoreApi.Context
{
    public class ProvinceContext
    {
        private const string DbName = "netcore";
        private const string TableName = "province";
        private static readonly IMongoDatabase mongoDatabase = null;

        static ProvinceContext()
        {
            //var client = MongoUtil.GetMongoClient();
            //if (null != client)
            //{
            //    mongoDatabase = client.GetDatabase(DbName);
            //}
        }

        public IMongoCollection<Province> Province
        {
            get
            {
                return mongoDatabase.GetCollection<Province>(TableName);
            }
        }
    }
}