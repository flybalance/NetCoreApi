using NetCoreApi.Domain.Dto;
using NetCoreApi.Domain.Response;

namespace NetCoreApi.Service
{
    /// <summary>
    /// 学生信息Service层
    /// </summary>
    public interface IStudentService
    {
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
        ApiResponse<Student> FindStudentByName(string stuName);
    }
}