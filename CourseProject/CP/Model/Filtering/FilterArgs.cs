using CP.Core;

namespace CP.Model.Filtering
{
    //аргументи фільтрації. generic-тип
    public class SimpleFilterArgument<T>
    {
        public T Sample { get; set; }
        public SimpleComparer Comparer { get; set; }
    }
}
