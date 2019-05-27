using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NetCoreApi.Service.Domain.Dto;
using SmartSql;

namespace NetCoreApi.Service.Dao.Impl
{
    public class DetailUserDaoImpl : IDetailUserDao
    {
        private readonly ISqlMapper __sqlMapper;

        public DetailUserDaoImpl(IServiceProvider serviceProvider)
        {
            __sqlMapper = serviceProvider.GetSmartSql("SmartSqlSampleChapterOne").SqlMapper;
        }

        public DetailUser FindById(long id)
        {
            return __sqlMapper.QuerySingle<DetailUser>(new RequestContext
            {
                Scope = "DetailUser",
                SqlId = "FindById",
                Request = new { Id = id }
            });
        }

        public IList<DetailUser> Query(object queryParams)
        {
            return __sqlMapper.Query<DetailUser>(new RequestContext
            {
                Scope = "DetailUser",
                SqlId = "QueryParams",
                Request = queryParams
            });
        }

        public long Save(DetailUser detailUser)
        {
            return __sqlMapper.ExecuteScalar<long>(new RequestContext
            {
                Scope = "DetailUser",
                SqlId = "Insert",
                Request = detailUser
            });
        }

        public int Update(DetailUser detailUser)
        {
            return __sqlMapper.Execute(new RequestContext
            {
                Scope = "DetailUser",
                SqlId = "Update",
                Request = detailUser
            });
        }

        public void DeleteById(long id)
        {
            __sqlMapper.Execute(new RequestContext
            {
                Scope = "DetailUser",
                SqlId = "DeleteById",
                Request = new { Id = id }
            });
        }
    }
}
