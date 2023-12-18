using Nest;

namespace ElasticSearch.Nest.QueryBuilder
{
    public interface IFilterItem<T> where T : class
    {
        public QueryContainer GetQuery(QueryContainerDescriptor<T> q);
        public QueryContainer GetInverseQuery(QueryContainerDescriptor<T> q);
    }
}
