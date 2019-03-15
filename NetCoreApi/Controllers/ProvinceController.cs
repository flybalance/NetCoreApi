using Microsoft.AspNetCore.Mvc;
using NetCoreApi.Domain.Dto;
using NetCoreApi.Domain.Response;
using NetCoreApi.Service;

namespace NetCoreApi.Controllers
{
    [Produces("application/json")]
    [Route("api/province/[action]")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {
        private readonly IProvinceService _provinceService;

        /// <summary>
        /// 通过构造函数方式注入容器
        /// </summary>
        /// <param name="provinceService"></param>
        public ProvinceController(IProvinceService provinceService)
        {
            _provinceService = provinceService;
        }

        [HttpPost]
        public ApiResponse<bool> AddProvince(Province province)
        {
            return _provinceService.AddProvince(province);
        }

        [HttpGet("{id}")]
        public ApiResponse<bool> DeleteProvinceById(long id)
        {
            return _provinceService.DeleteProvinceById(id);
        }

        [HttpGet("{id}")]
        public ApiResponse<Province> FindProvinceById(long id)
        {
            return _provinceService.FindProvinceById(id);
        }
    }
}