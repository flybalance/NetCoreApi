using NetCoreApi.Common.Interface;
using NetCoreApi.Domain.Dto;
using System.Collections.Generic;

namespace NetCoreApi.Dao
{
    /// <summary>
    /// 学生信息Dao层
    /// </summary>
    public interface IStudentDao:IDependency
    {
        /// <summary>
        ///  添加学生信息
        /// </summary>
        /// <param name="student"></param>
        void AddStudent(Student student);

        /// <summary>
        /// 根据id获取学生信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Student FindStudentById(long id);

        /// <summary>
        /// 根据name获取学生信息
        /// </summary>
        /// <param name="stuName"></param>
        /// <returns></returns>
        IList<Student> FindStudentByName(string stuName);
    }
}