using NetCoreApi.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApi.Dao
{
    public interface IProvinceDao
    {
        void AddProvince(Province province);

        void UpdateProvinceById(Province province);

        Province FindProvinceById(long id);

        IList<Province> QueryProvinceByCondition(Dictionary<string, object> parmsters);

        void DeleteProvinceById(long id);
    }
}
