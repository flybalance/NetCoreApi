using NetCoreApi.Service.Common.Interface;
using NetCoreApi.Service.Domain.Dto;
using NetCoreApi.Service.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreApi.Service.Service
{
    public interface INewsContentService: IDependency
    {
        ApiResponse<IEnumerable<NewsContent>> GetNewsContents();
    }
}
