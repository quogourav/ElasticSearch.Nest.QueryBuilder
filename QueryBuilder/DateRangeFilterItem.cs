﻿using Nest;
using System.Linq.Expressions;

namespace ElasticSearch.Nest.QueryBuilder
{
    public class DateRangeFilterItem<T, TTerm> : IFilterItem<T> where T : class
    {
        public DateRangeFilterItem(Expression<Func<T, object>> field, DateTime? min, DateTime? max)
        {
            Field = field;
            MinValue = min;
            MaxValue = max;
        }

        public Expression<Func<T, object>> Field { get; set; }

        public DateTime? MinValue { get; set; }
        
        public DateTime? MaxValue { get; set; }

        public QueryContainer GetInverseQuery(QueryContainerDescriptor<T> q)
        {
            return !q.DateRange(c =>
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
            return q.DateRange(c =>
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
