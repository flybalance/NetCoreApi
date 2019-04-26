using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nest;
using NetCoreApi.Service.Domain.Dto;
using NetCoreApi.Service.Domain.Response;

namespace NetCoreApi.Service.Service.Impl
{
    public class NewsContentServiceImpl : INewsContentService
    {
        private readonly IElasticClient _elasticClient;

        public NewsContentServiceImpl(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public ApiResponse<IEnumerable<NewsContent>> GetNewsContents()
        {
            ApiResponse<IEnumerable<NewsContent>> apiResponse = ApiResponse<IEnumerable<NewsContent>>.GetInstance();

            List<Func<QueryContainerDescriptor<NewsContent>, QueryContainer>> ltMust = GetCondition();
            var response = _elasticClient.Search<NewsContent>(s => s.Index("news_content").
                Query(
                    q =>
                        q.Bool(b =>
                            b.Must(
                                ltMust.ToArray()
                                    ))).From(0).Size(2));

            return apiResponse.Success(response.Documents.ToList());
        }

        private List<Func<QueryContainerDescriptor<NewsContent>, QueryContainer>> GetCondition()
        {
            List<Func<QueryContainerDescriptor<NewsContent>, QueryContainer>> ltMust =
                new List<Func<QueryContainerDescriptor<NewsContent>, QueryContainer>>();

            //ltMust.Add(q =>
            //{
            //    // t => t.Field(f => f.Source).Query("我的有色网")
            //    return q.Term(t => t.Field(f => f.ShowTime).Value(1492771920000L));
            //});

            ltMust.Add(q =>
            {
                return q.Match(t => t.Field(f => f.CreateUserName).Query("王粉婷"));
            });

            //ltMust.Add(q =>
            //{
            //    return q.Match(t => t.Field(f => f.Title).Query("炭市场一周评述"));
            //});

            return ltMust;
        }
    }
}
