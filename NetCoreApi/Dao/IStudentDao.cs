﻿using NetCoreApi.Domain.Dto;

namespace NetCoreApi.Dao
{
    /// <summary>
    /// 学生信息Dao层
    /// </summary>
    public interface IStudentDao
    {
        /// <summary>
        /// 根据id获取学生信息 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Student FindStudentById(long id);
    }
}