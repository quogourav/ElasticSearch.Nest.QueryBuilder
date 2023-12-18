using Nest;

namespace ElasticSearch.Nest.QueryBuilder
{
    public class QueryBuilder<T> : IFilterItem<T> where T : class
    {
        public QueryBuilder(OperatorType type, IEnumerable<IFilterItem<T>> filterItems)
        {
            OperatorType = type;
            FilterItems = filterItems;            
        }

        public OperatorType OperatorType { get; set; }

        public IEnumerable<IFilterItem<T>>? FilterItems { get; set; }

        public QueryContainer GetQuery(QueryContainerDescriptor<T> q)
        {
            if (FilterItems == null || !FilterItems.Any())
            {
                throw new ArgumentException("FilterItems cannot be empty");
            }

            QueryContainer container = FilterItems.First().GetQuery(q);
            for (var i = 1; i < FilterItems.Count(); i++)
            {
                if (OperatorType == OperatorType.And)
                {
                    container = container && FilterItems.ElementAt(i).GetQuery(q);
                }
                else
                {
                    container = container || FilterItems.ElementAt(i).GetQuery(q);
                }
            }
            return container;
        }

        public QueryContainer GetInverseQuery(QueryContainerDescriptor<T> q)
        {
            if (FilterItems == null || !FilterItems.Any())
            {
                throw new ArgumentException("FilterItems cannot be empty");
            }

            QueryContainer container = FilterItems.First().GetQuery(q);
            for (var i = 1; i < FilterItems.Count(); i++)
            {
                if (OperatorType == OperatorType.And)
                {
                    container = container && FilterItems.ElementAt(i).GetQuery(q);
                }
                else
                {
                    container = container || FilterItems.ElementAt(i).GetQuery(q);
                }
            }
            return !container;
        }
    }
}
