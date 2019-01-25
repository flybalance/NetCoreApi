using Microsoft.AspNetCore.Mvc;
using NetCoreApi.Domain.Dto;
using NetCoreApi.Service;

namespace NetCoreApi.Controllers
{
    /// <summary>
    /// 学生信息服务控制层
    /// </summary>
    [Route("api/info/stu")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentService _studentService { get; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="studentService"></param>
        public StudentController(IStudentService studentService)
        {
            this._studentService = studentService;
        }

        /// <summary>
        /// 根据id查询学生信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<Student> FindStudentById(long id)
        {
            return _studentService.FindStudentById(id);
        }
    }
}