using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace NetCoreApi.Controllers
{
    /// <summary>
    /// Version1Controller
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Version1Controller : ControllerBase
    {
        /// <summary>
        /// Version1 Get方法
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Value1 from Version 1", "value2 from Version 1" };
        }
    }


}