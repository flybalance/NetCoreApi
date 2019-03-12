using NetCoreApi.Domain.Dto;
using NetCoreApi.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApi.Service
{
    public interface IProvinceService
    {
        ApiResponse<bool> AddProvince(Province province);

        ApiResponse<bool> DeleteProvinceById(long id);

        ApiResponse<Province> FindProvinceById(long id);
    }
}
