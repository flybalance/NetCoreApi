using MongoDB.Driver;
using NetCoreApi.Service.Common.Utils;
using NetCoreApi.Service.Domain.Dto;
using System.Collections.Generic;

namespace NetCoreApi.Service.Dao.Impl
{
    /// <summary>
    /// 学生信息Dao层实现类
    /// </summary>
    public class StudentDaoImp : IStudentDao
    {
        private readonly IMongoCollection<Student> _studentContext = null;

        public StudentDaoImp()
        {
            _studentContext = MongoUtil<Student>.GetMongoCollection("student");
        }

        /// <summary>
        /// 添加学生信息
        /// </summary>
        /// <param name="student"></param>
        public void AddStudent(Student student)
        {
            _studentContext.InsertOneAsync(student);
        }

        /// <summary>
        /// 根据id获取学生信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Student FindStudentById(long id)
        {
            return _studentContext.Find(t => t.Id == id).SingleOrDefault();
        }

        /// <summary>
        /// 根据name获取学生信息
        /// </summary>
        /// <param name="stuName"></param>
        /// <returns></returns>
        public IList<Student> FindStudentByName(string stuName)
        {
            return _studentContext.Find(t => t.StuName.Contains(stuName)).ToList();
        }
    }
}