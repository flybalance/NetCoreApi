using MongoDB.Driver;
using NetCoreApi.Common.Utils;
using NetCoreApi.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetCoreApi.Dao.Impl
{
    public class ProvinceDaoImpl : IProvinceDao
    {
        private readonly IMongoCollection<Province> _provinceContext = null;

        public ProvinceDaoImpl()
        {
            _provinceContext = MongoUtil<Province>.GetMongoCollection("province");
        }

        public void AddProvince(Province province)
        {
            _provinceContext.InsertOneAsync(province);
        }

        public void DeleteProvinceById(long id)
        {
            _provinceContext.DeleteOneAsync(t => t.ProvinceId == id);
        }

        public Province FindProvinceById(long id)
        {
            return _provinceContext.Find(t => t.ProvinceId == id).SingleOrDefault();
        }

        public IList<Province> QueryProvinceByCondition(Dictionary<string, object> parmsters)
        {
            throw new NotImplementedException();
        }

        public void UpdateProvinceById(Province province)
        {
            //provinceContext.Province.ReplaceOne(t=>t.ProvinceId == province.ProvinceId);
            throw new NotImplementedException();
        }
    }
}