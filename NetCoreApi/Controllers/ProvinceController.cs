using Microsoft.AspNetCore.Mvc;
using NetCoreApi.Domain.Dto;
using NetCoreApi.Domain.Response;
using NetCoreApi.Service;

namespace NetCoreApi.Controllers
{
    /// <summary>
    /// 省份信息
    /// </summary>
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

        /// <summary>
        /// 新增省份
        /// </summary>
        /// <param name="province"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResponse<bool> AddProvince(Province province)
        {
            return _provinceService.AddProvince(province);
        }

        /// <summary>
        /// 根据id删除省份
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ApiResponse<bool> DeleteProvinceById(long id)
        {
            return _provinceService.DeleteProvinceById(id);
        }

        /// <summary>
        /// 根据id查找省份
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ApiResponse<Province> FindProvinceById(long id)
        {
            return _provinceService.FindProvinceById(id);
        }
    }
}