using Moq;
using NetCoreApi.Service.Dao;
using NetCoreApi.Service.Dao.Impl;
using NetCoreApi.Service.Domain.Dto;
using System;
using Xunit;

namespace NetCoreApi.Service.Test.Dao
{
    public class DetailUserDaoImplTest
    {
        Mock<IServiceProvider> mockDetailUserDao = new Mock<IServiceProvider>();
        DetailUserDaoImpl detailUserDaoImpl;
        public DetailUserDaoImplTest()
        {
            detailUserDaoImpl = new DetailUserDaoImpl(mockDetailUserDao.Object);
        }

        [Fact]
        public void FindByIdTest()
        {
            DetailUser detailUser = detailUserDaoImpl.FindById(2);

            Assert.True(null != detailUser);
        }
    }
}
