using Nest;
using System;
using System.Linq.Expressions;

namespace ElasticSearch.Nest.QueryBuilder
{
    public class RangeFilterItem<T, TTerm> : IFilterItem<T> where T : class
    {
        public RangeFilterItem(Expression<Func<T, object>> field, double? min, double? max)
        {
            Field = field;
            MinValue = min;
            MaxValue = max;
        }

        public Expression<Func<T, object>> Field { get; set; }
        public double? MinValue { get; set; }
        public double? MaxValue { get; set; }

        public QueryContainer GetInverseQuery(QueryContainerDescriptor<T> q)
        {
            return !q.Range(c =>
            {
                if (MinValue == null && MaxValue != null)
                {
                    c.Field(Field)
                     .LessThanOrEquals(MaxValue);
                }
                else if (MinValue != null && MaxValue == null)
                {
                    c.Field(Field)
                    .GreaterThanOrEquals(MinValue);
                }
                else if (MinValue != null && MaxValue != null)
                {
                    c.Field(Field)
                    .GreaterThanOrEquals(MinValue)
                    .LessThanOrEquals(MaxValue);
                }
                return c;
            });
        }

        public QueryContainer GetQuery(QueryContainerDescriptor<T> q)
        {
            return q.Range(c =>
            {
                if (MinValue == null && MaxValue != null)
                {
                    c.Field(Field)
                     .LessThanOrEquals(MaxValue);
                }
                else if (MinValue != null && MaxValue == null)
                {
                    c.Field(Field)
                    .GreaterThanOrEquals(MinValue);
                }
                else if (MinValue != null && MaxValue != null)
                {
                    c.Field(Field)
                    .GreaterThanOrEquals(MinValue)
                    .LessThanOrEquals(MaxValue);
                }
                return c;
            });
        }
    }

}
