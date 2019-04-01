using MongoDB.Bson.Serialization.Attributes;
using System;

namespace NetCoreApi.Service.Domain.Dto
{
    /// <summary>
    /// 学信信息实体
    /// </summary>
    [Serializable]
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
        ///   /// <param name="id"></param>
        /// <param name="stuName"></param>
        /// <param name="sex"></param>
        /// <param name="age"></param>
        public Student(long id, string stuName, int sex, int age)
        {
            Id = id;
            StuName = stuName;
            Sex = sex;
            Age = age;
        }

        /// <summary>
        /// 流水号
        /// </summary>
        [BsonId]
        public long Id { get; set; }

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
            return $"[Id={Id} ,StuName={StuName}, Sex={Sex}, Age={Age}]";
        }
    }
}