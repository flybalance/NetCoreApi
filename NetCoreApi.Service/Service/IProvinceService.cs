using NetCoreApi.Service.Common.Interface;
using NetCoreApi.Service.Domain.Dto;
using NetCoreApi.Service.Domain.Response;

namespace NetCoreApi.Service.Service
{
    public interface IProvinceService : IDependency
    {
        ApiResponse<bool> AddProvince(Province province);

        ApiResponse<bool> DeleteProvinceById(long id);

        ApiResponse<Province> FindProvinceById(long id);
    }
}