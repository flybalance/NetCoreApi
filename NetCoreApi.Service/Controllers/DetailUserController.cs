using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreApi.Service.Domain.Dto;
using NetCoreApi.Service.Domain.Response;
using NetCoreApi.Service.Service;

namespace NetCoreApi.Service.Controllers
{
    [Produces("application/json")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class DetailUserController : ControllerBase
    {
        private readonly IDetailUserService __detailUserService;

        public DetailUserController(IDetailUserService detailUserService)
        {
            __detailUserService = detailUserService;
        }

        [HttpPost]
        public ApiResponse<long> Save(DetailUser detailUser)
        {
            return __detailUserService.Save(detailUser);
        }

        [HttpPost]
        public ApiResponse<bool> Update(DetailUser detailUser)
        {
            return __detailUserService.Update(detailUser);
        }

        [HttpGet]
        public ApiResponse<DetailUser> FindById(long id)
        {
            return __detailUserService.FindById(id);
        }

        [HttpPost]
        public ApiResponse<IList<DetailUser>> Query(object queryParams)
        {
            return __detailUserService.Query(queryParams);
        }

        [HttpGet]
        public ApiResponse<bool> DeleteById(long id)
        {
            return __detailUserService.DeleteById(id);
        }

    }
}