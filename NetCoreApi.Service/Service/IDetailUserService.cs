using NetCoreApi.Service.Common.Interface;
using NetCoreApi.Service.Domain.Dto;
using NetCoreApi.Service.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApi.Service.Service
{
    public interface IDetailUserService : IDependency
    {
        ApiResponse<long> Save(DetailUser detailUser);

        ApiResponse<bool> Update(DetailUser detailUser);

        ApiResponse<DetailUser> FindById(long id);

        ApiResponse<IList<DetailUser>> Query(object queryParams);

        ApiResponse<bool> DeleteById(long id);
    }
}
