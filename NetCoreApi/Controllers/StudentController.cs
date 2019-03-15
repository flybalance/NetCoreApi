using Microsoft.AspNetCore.Mvc;
using NetCoreApi.Domain.Dto;
using NetCoreApi.Domain.Response;
using NetCoreApi.Service;
using System.Collections.Generic;

namespace NetCoreApi.Controllers
{
    /// <summary>
    /// 学生信息服务控制层
    /// </summary>
    [Produces("application/json")]
    [Route("api/student/[action]")]
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
        [HttpGet]
        public ApiResponse<Student> FindStudentById(long id)
        {
            return _studentService.FindStudentById(id);
        }

        /// <summary>
        /// 根据name查询学生信息
        /// </summary>
        /// <param name="stuName"></param>
        /// <returns></returns>
        [HttpGet]
        public ApiResponse<IList<Student>> FindStudentByName(string stuName)
        {
            return _studentService.FindStudentByName(stuName);
        }
    }
}