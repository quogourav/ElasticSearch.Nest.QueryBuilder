using Nest;
using System.Linq.Expressions;

namespace ElasticSearch.Nest.QueryBuilder
{
    public class WildcardFilterItem<T> : IFilterItem<T> where T : class
    {
        public WildcardFilterItem(Expression<Func<T, object>> field, string values)
        {
            Field = field;
            Value = values;
        }

        public Expression<Func<T, object>> Field { get; set; }

        public string Value { get; set; }

        public QueryContainer GetInverseQuery(QueryContainerDescriptor<T> q)
        {
            return !q.Wildcard(Field, Value);
        }

        public QueryContainer GetQuery(QueryContainerDescriptor<T> q)
        {
            return q.Wildcard(Field, Value);
        }
    }
}
