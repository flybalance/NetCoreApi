using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreApi.Domain.Dto;
using NetCoreApi.Domain.Dto.response;
using NetCoreApi.Service;

namespace NetCoreApi.Controllers
{
    [Route("api/province/[action]")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {
        private IProvinceService ProvinceService { get; }

        public ProvinceController(IProvinceService provinceService)
        {
            ProvinceService = provinceService;
        }

        [HttpPost]
        public ApiResponse<bool> AddProvince(Province province)
        {
            return ProvinceService.AddProvince(province);
        }

        [HttpGet("{id}")]
        public ApiResponse<bool> DeleteProvinceById(long id)
        {
            return ProvinceService.DeleteProvinceById(id);
        }

        [HttpGet("{id}")]
        public ApiResponse<Province> FindProvinceById(long id)
        {
            return ProvinceService.FindProvinceById(id);
        }
    }
}
