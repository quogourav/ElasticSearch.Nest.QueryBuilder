using Nest;
using System.Linq.Expressions;

namespace ElasticSearch.Nest.QueryBuilder
{
    public class MatchFilterItem<T> : IFilterItem<T> where T : class
    {
        public MatchFilterItem(Expression<Func<T, object>> field, string value)
        {
            Field = field;
            Value = value;
        }

        public Expression<Func<T, object>> Field { get; set; }
        public string Value { get; set; }

        public QueryContainer GetInverseQuery(QueryContainerDescriptor<T> q)
        {
            return !q.Match(m => m
                   .Field(Field)
                   .Query(Value));
        }

        public QueryContainer GetQuery(QueryContainerDescriptor<T> q)
        {
            return q.Match(m => m
                   .Field(Field)
                   .Query(Value));
        }
    }
}
