using Microsoft.AspNetCore.Mvc;
using NetCoreApi.Service.Domain.Dto;
using NetCoreApi.Service.Domain.Response;
using NetCoreApi.Service.Service;
using System.Collections.Generic;

namespace NetCoreApi.Service.Controllers
{
    /// <summary>
    /// 学生信息服务控制层
    /// </summary>
    [Produces("application/json")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="studentService"></param>
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        /// <summary>
        /// 添加学生信息
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResponse<bool> AddStudent(Student student)
        {
            return _studentService.AddStudent(student);
        }

        /// <summary>
        /// 根据id查询学生信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ApiResponse<Student> FindStudentById(long id)
        {
            return _studentService.FindStudentById(id);
        }

        /// <summary>
        /// 根据name查询学生信息
        /// </summary>
        /// <param name="stuName"></param>
        /// <returns></returns>
        [HttpGet("{stuName}")]
        public ApiResponse<IList<Student>> FindStudentByName(string stuName)
        {
            return _studentService.FindStudentByName(stuName);
        }
    }
}