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
    public class FilterArgs
    {
        public int Axles { get; set; }
        public int PassengersCapacity { get; set; }

    }
}
