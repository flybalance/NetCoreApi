using NetCoreApi.Service.Common.Extention;
using NetCoreApi.Service.Dao;
using NetCoreApi.Service.Domain.Dto;
using NetCoreApi.Service.Domain.Response;
using NetCoreApi.Service.Exception;
using NetCoreApi.Service.Exception.Code;
using System.Collections.Generic;

namespace NetCoreApi.Service.Service.Impl
{
    /// <summary>
    /// 学生信息Service层实现类
    /// </summary>
    public class StudentServiceImpl : IStudentService
    {
        private readonly IStudentDao _studentDao;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="studentDao"></param>
        public StudentServiceImpl(IStudentDao studentDao)
        {
            _studentDao = studentDao;
        }

        /// <summary>
        /// 添加学生信息
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public ApiResponse<bool> AddStudent(Student student)
        {
            ApiResponse<bool> apiResponse = ApiResponse<bool>.GetInstance();
            if (null == student)
            {
                EnumOperate.EnumItem enumItem = StudentErrorCode.REQUEST_PARAM_ENTITY_IS_NULL.GetBaseDescription();
                apiResponse.Error(enumItem.Code, enumItem.Message);
            }

            try
            {
                _studentDao.AddStudent(student);
                apiResponse.Success(true);
            }
            catch (System.Exception exception)
            {
                apiResponse.Error(exception.Message);
            }

            return apiResponse;
        }

        /// <summary>
        /// 根据id获取学生信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ApiResponse<Student> FindStudentById(long id)
        {
            ApiResponse<Student> apiResponse = ApiResponse<Student>.GetInstance();

            try
            {
                Student student = _studentDao.FindStudentById(id);
                apiResponse.Success(student);
            }
            catch (System.Exception exception)
            {
                apiResponse.Error(exception.Message);
            }

            return apiResponse;
        }

        /// <summary>
        /// 根据name获取学生信息
        /// </summary>
        /// <param name="stuName"></param>
        /// <returns></returns>
        public ApiResponse<IList<Student>> FindStudentByName(string stuName)
        {
            ApiResponse<IList<Student>> apiResponse = ApiResponse<IList<Student>>.GetInstance();

            if (string.IsNullOrEmpty(stuName))
            {
                EnumOperate.EnumItem enumItem = BaseErrorCode.REQUEST_PARAM_ERROR.GetBaseDescription();
                apiResponse.Error(enumItem.Code, enumItem.Message);
            }

            try
            {
                var studentList = _studentDao.FindStudentByName(stuName);
                apiResponse.Success(studentList);
            }
            catch (System.Exception exception)
            {
                apiResponse.Error(exception.Message);
            }

            return apiResponse;
        }
    }
}