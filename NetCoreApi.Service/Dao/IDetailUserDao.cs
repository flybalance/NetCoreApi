using NetCoreApi.Service.Common.Interface;
using NetCoreApi.Service.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApi.Service.Dao
{
    public interface IDetailUserDao : IDependency
    {
        long Save(DetailUser detailUser);

        int Update(DetailUser detailUser);

        DetailUser FindById(long id);

        IList<DetailUser> Query(object queryParams);

        void DeleteById(long id);
    }
}
