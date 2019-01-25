using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace NetCoreApi.Controllers
{
    /// <summary>
    /// Version2Controller
    /// </summary>
    [ApiVersion("2.0")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Version2Controller : ControllerBase
    {
        /// <summary>
        /// Version2 Get方法
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1 from Version 2", "value2 from Version 2" };
        }
    }
}