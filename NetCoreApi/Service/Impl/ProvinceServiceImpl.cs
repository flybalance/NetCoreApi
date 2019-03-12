using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreApi.Dao;
using NetCoreApi.Domain.Dto;
using NetCoreApi.Domain.Response;

namespace NetCoreApi.Service.Impl
{
    public class ProvinceServiceImpl : IProvinceService
    {
        private IProvinceDao ProvinceDao { get; }

        public ProvinceServiceImpl(IProvinceDao provinceDao)
        {
            ProvinceDao = provinceDao;
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
                ProvinceDao.AddProvince(province);
                apiResponse.Success(true);
            }
            catch (Exception)
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
                ProvinceDao.DeleteProvinceById(id);
                apiResponse.Success(true);
            }
            catch (Exception)
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
                Province province = ProvinceDao.FindProvinceById(id);
                apiResponse.Success(province);
            }
            catch (Exception)
            {
                throw;
            }

            return apiResponse;
        }
    }
}
