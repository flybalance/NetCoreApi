using NetCoreApi.Dao;
using NetCoreApi.Domain.Dto;
using NetCoreApi.Domain.Response;

namespace NetCoreApi.Service.Impl
{
    /// <summary>
    /// 学生信息Service层实现类
    /// </summary>
    public class StudentServiceImpl : IStudentService
    {
        private IStudentDao StudentDao { get; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="studentDao"></param>
        public StudentServiceImpl(IStudentDao studentDao)
        {
            StudentDao = studentDao;
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
                Student student = StudentDao.FindStudentById(id);
                if (null == student)
                {
                    apiResponse.Error();
                }

                apiResponse.Success(student);
            }
            catch (System.Exception)
            {
                throw;
            }

            return apiResponse;
        }

        /// <summary>
        /// 根据name获取学生信息
        /// </summary>
        /// <param name="stuName"></param>
        /// <returns></returns>
        public ApiResponse<Student> FindStudentByName(string stuName)
        {
            ApiResponse<Student> apiResponse = ApiResponse<Student>.GetInstance();

            if (string.IsNullOrEmpty(stuName))
            {
                apiResponse.Error();
            }

            try
            {
                Student student = StudentDao.FindStudentByName(stuName);
                if (null == student)
                {

                }

                apiResponse.Success(student);
            }
            catch (System.Exception)
            {
                throw;
            }

            return apiResponse;
        }
    }
}