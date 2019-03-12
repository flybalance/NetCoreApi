using Microsoft.AspNetCore.Mvc;
using NetCoreApi.Domain.Dto;
using NetCoreApi.Domain.Dto.response;
using NetCoreApi.Service;

namespace NetCoreApi.Controllers
{
    /// <summary>
    /// 学生信息服务控制层
    /// </summary>
    [Route("api/student/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentService StudentService { get; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="studentService"></param>
        public StudentController(IStudentService studentService)
        {
            StudentService = studentService;
        }

        /// <summary>
        /// 根据id查询学生信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ApiResponse<Student> FindStudentById(long id)
        {
            return StudentService.FindStudentById(id);
        }

        /// <summary>
        /// 根据name查询学生信息
        /// </summary>
        /// <param name="stuName"></param>
        /// <returns></returns>
        [HttpGet("{stuName}")]
        public ApiResponse<Student> FindStudentByName(string stuName)
        {
            return StudentService.FindStudentByName(stuName);
        }
    }
}