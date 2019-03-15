using NetCoreApi.Common.Interface;
using NetCoreApi.Domain.Dto;
using NetCoreApi.Domain.Response;

namespace NetCoreApi.Service
{
    public interface IProvinceService : IDependency
    {
        ApiResponse<bool> AddProvince(Province province);

        ApiResponse<bool> DeleteProvinceById(long id);

        ApiResponse<Province> FindProvinceById(long id);
    }
}