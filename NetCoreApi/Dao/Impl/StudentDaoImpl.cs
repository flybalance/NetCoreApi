using NetCoreApi.Domain.Dto;

namespace NetCoreApi.Dao.Impl
{
    /// <summary>
    /// 学生信息Dao层实现类
    /// </summary>
    public class StudentDaoImp : IStudentDao
    {
        /// <summary>
        /// 根据id获取学生信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Student FindStudentById(long id)
        {
            return new Student("张三", 1, 16);
        }
    }
}