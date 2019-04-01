using NetCoreApi.Service.Common.Interface;
using NetCoreApi.Service.Domain.Dto;
using System.Collections.Generic;

namespace NetCoreApi.Service.Dao
{
    public interface IProvinceDao : IDependency
    {
        void AddProvince(Province province);

        void UpdateProvinceById(Province province);

        Province FindProvinceById(long id);

        IList<Province> QueryProvinceByCondition(Dictionary<string, object> parmsters);

        void DeleteProvinceById(long id);
    }
}