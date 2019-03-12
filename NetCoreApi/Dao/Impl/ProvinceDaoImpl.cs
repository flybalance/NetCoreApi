using MongoDB.Driver;
using NetCoreApi.Common.Utils;
using NetCoreApi.Domain.Dto;
using NetCoreApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetCoreApi.Dao.Impl
{
    public class ProvinceDaoImpl : IProvinceDao
    {
        private readonly ProvinceContext provinceContext = null;

        public ProvinceDaoImpl()
        {
            provinceContext = SingletonUtil<ProvinceContext>.GetInstance;
        }

        public void AddProvince(Province province)
        {
            provinceContext.Province.InsertOneAsync(province);
        }

        public void DeleteProvinceById(long id)
        {
            provinceContext.Province.DeleteOneAsync(t => t.ProvinceId == id);
        }

        public Province FindProvinceById(long id)
        {
            return provinceContext.Province.Find(t => t.ProvinceId == id).SingleOrDefault();
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
