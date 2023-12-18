using Nest;
using System.Linq.Expressions;

namespace ElasticSearch.Nest.QueryBuilder
{
    public class ExistFilterItem<T> : IFilterItem<T> where T : class
    {
        public ExistFilterItem(Expression<Func<T, object>> field)
        {
            Field = field;
        }

        public Expression<Func<T, object>> Field { get; set; }

        public QueryContainer GetInverseQuery(QueryContainerDescriptor<T> q)
        {
            return !q.Exists(m =>
            {
                m.Field(Field);

                return m;
            });
        }

        public QueryContainer GetQuery(QueryContainerDescriptor<T> q)
        {
            return q.Exists(m =>
            {
                m.Field(Field);

                return m;
            });
        }
    }
}
