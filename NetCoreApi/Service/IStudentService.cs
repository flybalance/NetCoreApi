using NetCoreApi.Domain.Dto;

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
        Student FindStudentById(long id);
    }
}