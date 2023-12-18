using Nest;
using System.Linq.Expressions;

namespace ElasticSearch.Nest.QueryBuilder
{
    public class TermFilterItem<T, TTerm> : IFilterItem<T> where T : class
    {
        public TermFilterItem(Expression<Func<T, object>> field, TTerm value)
        {
            Field = field;
            Value = value;
        }

        public Expression<Func<T, object>> Field { get; set; }

        public TTerm Value { get; set; }

        public QueryContainer GetInverseQuery(QueryContainerDescriptor<T> q)
        {
            return !q.Term(m =>
            {
                m.Field(Field).Value(Value);

                return m;
            });
        }

        public QueryContainer GetQuery(QueryContainerDescriptor<T> q)
        {
            return q.Term(m =>
            {
                    m.Field(Field).Value(Value);

                return m;
            });
        }

    }
}
