using CP.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP.Model.Filtering
{
    public enum TFilter
    {
        ByCapacity,
        ByNumberOfAxles,
        ByAvgWeigh
    }
    public class SimpleFilterArgument<T>
    {
        public T Sample { get; set; }
        public SimpleComparer Comparer { get; set; }
    }
    public class TransportFilterArgs
    {
        public SimpleFilterArgument<int> Axles { get; set; }
        public SimpleFilterArgument<string> Model { get; set; }
        public SimpleFilterArgument<EEngineType> EngineType { get; set; }
        public SimpleFilterArgument<int> Doors { get; set; }
        public SimpleFilterArgument<int> PassengerCapacity { get; set; }
        public SimpleFilterArgument<int> Seats { get; set; }
        public SimpleFilterArgument<int> EnginePower { get; set; }
        public SimpleFilterArgument<int> LowClearance { get; set; }
    }
}
