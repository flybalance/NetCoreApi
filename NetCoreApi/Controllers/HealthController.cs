using Microsoft.AspNetCore.Mvc;

namespace NetCoreApi.Controllers
{
    [Produces("application/json")]
    [Route("api/health")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        /// <summary>
        /// consul健康检查
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get() => Ok("ok");
    }
}