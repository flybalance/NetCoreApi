namespace NetCoreApi.Domain.Dto
{
    /// <summary>
    /// 学信信息实体
    /// </summary>
    public class Student
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public Student()
        {
        }

        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="stuName"></param>
        /// <param name="sex"></param>
        /// <param name="age"></param>
        public Student(string stuName, int sex, int age)
        {
            this.StuName = stuName;
            this.Sex = sex;
            this.Age = age;
        }

        /// <summary>
        /// 学生姓名
        /// </summary>
        public string StuName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// ToString方法重写
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"[StuName={StuName}, Sex={Sex}, Age={Age}]";
        }
    }
}