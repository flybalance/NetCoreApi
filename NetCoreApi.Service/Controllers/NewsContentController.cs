using Microsoft.AspNetCore.Mvc;
using NetCoreApi.Service.Domain.Dto;
using NetCoreApi.Service.Domain.Response;
using NetCoreApi.Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApi.Service.Controllers
{
    /// <summary>
    /// 新闻信息(ElasticSearch)
    /// </summary>
    [Produces("application/json")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class NewsContentController : ControllerBase
    {
        private INewsContentService _newsContentService;

        public NewsContentController(INewsContentService newsContentService)
        {
            _newsContentService = newsContentService;
        }

        /// <summary>
        /// ElasticSearch查询新闻
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ApiResponse<IEnumerable<NewsContent>> GetNewsContents()
        {
            return _newsContentService.GetNewsContents();
        }
    }
}
