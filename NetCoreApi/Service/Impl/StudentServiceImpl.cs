using NetCoreApi.Dao;
using NetCoreApi.Domain.Dto;

namespace NetCoreApi.Service.Impl
{
    /// <summary>
    /// 学生信息Service层实现类
    /// </summary>
    public class StudentServiceImpl : IStudentService
    {
        private IStudentDao _studentDao { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentDao"></param>
        public StudentServiceImpl(IStudentDao studentDao)
        {
            this._studentDao = studentDao;
        }

        /// <summary>
        /// 根据id获取学生信息 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Student FindStudentById(long id)
        {
            return _studentDao.FindStudentById(id);
        }
    }
}