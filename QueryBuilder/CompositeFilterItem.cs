namespace ElasticSearch.Nest.QueryBuilder
{
    public class CompositeFilterItem<T> : QueryBuilder<T> where T : class
    {
        public CompositeFilterItem(OperatorType type, IEnumerable<IFilterItem<T>> filterItems): base(type, filterItems)
        {
        }
    }
}
