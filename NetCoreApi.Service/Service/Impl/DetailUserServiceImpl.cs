using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreApi.Service.Dao;
using NetCoreApi.Service.Domain.Dto;
using NetCoreApi.Service.Domain.Response;

namespace NetCoreApi.Service.Service.Impl
{
    public class DetailUserServiceImpl : IDetailUserService
    {
        private readonly IDetailUserDao __detailUserDao;

        public DetailUserServiceImpl(IDetailUserDao detailUserDao)
        {
            __detailUserDao = detailUserDao;
        }

        public ApiResponse<bool> DeleteById(long id)
        {
            ApiResponse<bool> apiResponse = ApiResponse<bool>.GetInstance();
            try
            {
                __detailUserDao.DeleteById(id);
                apiResponse.Success(true);
            }
            catch (System.Exception)
            {
                throw;
            }

            return apiResponse;
        }

        public ApiResponse<DetailUser> FindById(long id)
        {
            ApiResponse<DetailUser> apiResponse = ApiResponse<DetailUser>.GetInstance();
            try
            {
                DetailUser detailUser = __detailUserDao.FindById(id);
                apiResponse.Success(detailUser);
            }
            catch (System.Exception)
            {
                throw;
            }

            return apiResponse;
        }

        public ApiResponse<IList<DetailUser>> Query(object queryParams)
        {
            ApiResponse<IList<DetailUser>> apiResponse = ApiResponse<IList<DetailUser>>.GetInstance();
            if (null == queryParams)
            {
                return apiResponse.Error();
            }

            try
            {
                IList<DetailUser> detailUsers = __detailUserDao.Query(queryParams);
                apiResponse.Success(detailUsers);
            }
            catch (System.Exception)
            {
                throw;
            }

            return apiResponse;
        }

        public ApiResponse<long> Save(DetailUser detailUser)
        {
            ApiResponse<long> apiResponse = ApiResponse<long>.GetInstance();
            if (null == detailUser)
            {
                return apiResponse.Error();
            }

            try
            {
                long id = __detailUserDao.Save(detailUser);
                apiResponse.Success(id);
            }
            catch (System.Exception)
            {
                throw;
            }

            return apiResponse;
        }

        public ApiResponse<bool> Update(DetailUser detailUser)
        {
            ApiResponse<bool> apiResponse = ApiResponse<bool>.GetInstance();
            if (null == detailUser)
            {
                return apiResponse.Error();
            }

            try
            {
                __detailUserDao.Update(detailUser);
                apiResponse.Success(true);
            }
            catch (System.Exception)
            {
                throw;
            }

            return apiResponse;
        }
    }
}
