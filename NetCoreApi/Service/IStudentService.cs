using NetCoreApi.Common.Interface;
using NetCoreApi.Domain.Dto;
using NetCoreApi.Domain.Response;
using System.Collections.Generic;

namespace NetCoreApi.Service
{
    /// <summary>
    /// 学生信息Service层
    /// </summary>
    public interface IStudentService: IDependency
    {
        /// <summary>
        /// 添加学生信息
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        ApiResponse<bool> AddStudent(Student student);

        /// <summary>
        /// 根据id获取学生信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ApiResponse<Student> FindStudentById(long id);

        /// <summary>
        /// 根据name获取学生信息
        /// </summary>
        /// <param name="stuName"></param>
        /// <returns></returns>
        ApiResponse<IList<Student>> FindStudentByName(string stuName);
    }
}