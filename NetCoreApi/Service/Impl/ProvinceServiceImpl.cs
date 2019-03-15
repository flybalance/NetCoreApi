using NetCoreApi.Dao;
using NetCoreApi.Domain.Dto;
using NetCoreApi.Domain.Response;

namespace NetCoreApi.Service.Impl
{
    public class ProvinceServiceImpl : IProvinceService
    {
        private readonly IProvinceDao _provinceDao;

        public ProvinceServiceImpl(IProvinceDao provinceDao)
        {
            _provinceDao = provinceDao;
        }

        public ApiResponse<bool> AddProvince(Province province)
        {
            ApiResponse<bool> apiResponse = ApiResponse<bool>.GetInstance();
            if (null == province)
            {
                return apiResponse.Error();
            }

            try
            {
                _provinceDao.AddProvince(province);
                apiResponse.Success(true);
            }
            catch (System.Exception)
            {
                throw;
            }

            return apiResponse;
        }

        public ApiResponse<bool> DeleteProvinceById(long id)
        {
            ApiResponse<bool> apiResponse = ApiResponse<bool>.GetInstance();

            try
            {
                _provinceDao.DeleteProvinceById(id);
                apiResponse.Success(true);
            }
            catch (System.Exception)
            {
                throw;
            }

            return apiResponse;
        }

        public ApiResponse<Province> FindProvinceById(long id)
        {
            ApiResponse<Province> apiResponse = ApiResponse<Province>.GetInstance();

            try
            {
                Province province = _provinceDao.FindProvinceById(id);
                apiResponse.Success(province);
            }
            catch (System.Exception exception)
            {
                apiResponse.Error(exception.Message);
            }

            return apiResponse;
        }
    }
}