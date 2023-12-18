using Nest;
using System.Linq.Expressions;

namespace ElasticSearch.Nest.QueryBuilder
{
    public class TermsFilterItem<T, TTerm> : IFilterItem<T> where T : class
    {
        public TermsFilterItem(Expression<Func<T, object>> field, IEnumerable<TTerm> values)
        {
            Field = field;
            Values = values;
        }

        public Expression<Func<T, object>> Field { get; set; }

        public IEnumerable<TTerm> Values { get; set; }

        public QueryContainer GetInverseQuery(QueryContainerDescriptor<T> q)
        {
            return !q.Terms(m =>
            {
                m.Field(Field).Terms<TTerm>(Values);
                return m;
            });
        }

        public QueryContainer GetQuery(QueryContainerDescriptor<T> q)
        {
            return q.Terms(m =>
            {
                m.Field(Field).Terms<TTerm>(Values);
                return m;
            });
        }
    }

}
